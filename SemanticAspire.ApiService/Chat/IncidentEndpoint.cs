using Azure;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Search.Documents.Indexes;
using Azure.Security.KeyVault.Secrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using SemanticAspire.Plugins;
using System.Runtime.CompilerServices;

namespace SemanticAspire.ApiService;

internal static class IncidentEndpoint
{
    internal static WebApplication MapIncidentEndpoints(
        this WebApplication app)
    {
        var chat = app.MapGroup("api/incident");

        chat.MapPost(
            pattern: "/",
            handler: GetChatCompletionAsync);

        return app;
    }

    private static async Task<IResult> GetChatCompletionAsync(
        ChatHistoryService chatHistory,
        SecretClient secretClient,
        ChatRequest chatRequest,
        [EnumeratorCancellation]
        CancellationToken cancellationToken
        )
    {
        var resourceBuilder = ResourceBuilder
            .CreateDefault()
            .AddService("SemanticAspireLogging");

        // Enable model diagnostics with sensitive data.
        AppContext.SetSwitch("Microsoft.SemanticKernel.Experimental.GenAI.EnableOTelDiagnosticsSensitive", true);
        var connectionString = secretClient.GetSecret("insights-connection").Value.Value;

        using var traceProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(resourceBuilder)
            .AddSource("Microsoft.SemanticKernel*")
            .AddAzureMonitorTraceExporter(options => options.ConnectionString = connectionString)
            .Build();

        using var meterProvider = Sdk.CreateMeterProviderBuilder()
            .SetResourceBuilder(resourceBuilder)
            .AddMeter("Microsoft.SemanticKernel*")
            .AddAzureMonitorMetricExporter(options => options.ConnectionString = connectionString)
            .Build();

        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            // Add OpenTelemetry as a logging provider
            builder.AddOpenTelemetry(options =>
            {
                options.SetResourceBuilder(resourceBuilder);
                options.AddAzureMonitorLogExporter(options => options.ConnectionString = connectionString);
                // Format log messages. This is default to false.
                options.IncludeFormattedMessage = true;
                options.IncludeScopes = true;
            });
            builder.SetMinimumLevel(LogLevel.Information);
        });

        var builder = Kernel.CreateBuilder();
        builder.Services.AddSingleton(loggerFactory);

        Uri searchEndpoint = new("https://srch-vzac3zroquyd4.search.windows.net");
        AzureKeyCredential searchCredential = new(secretClient.GetSecret("search-key").Value.Value);

        builder.Services.AddSingleton<SearchIndexClient>((_) => new SearchIndexClient(searchEndpoint, searchCredential));
        builder.Services.AddSingleton<IAzureSearchService<TroubleshootDataModel>, AzureSearchService<TroubleshootDataModel>>();
        builder.Services.AddSingleton<IAzureSearchService<IcmDataModel>, AzureSearchService<IcmDataModel>>();

        builder.AddAzureOpenAIChatCompletion(
           "gpt-4",
           "https://aoai-vzac3zroquyd4.services.ai.azure.com/",
           secretClient.GetSecret("gp4-endpoint-key").Value.Value);

        builder.AddAzureOpenAITextEmbeddingGeneration(
           "text-embedding-ada-002",
          "https://aoai-vzac3zroquyd4.services.ai.azure.com/",
          secretClient.GetSecret("gp4-endpoint-key").Value.Value);

        builder.Plugins.AddFromType<TroubleshootPlugin>("SearchPlugin");
        builder.Plugins.AddFromType<IcmPlugin>("IcmPlugin");

        Kernel kernel = builder.Build();

        var systemMessage =
            $$$"""
                You are Aioki, a helpful assisant for Azure IoT Operations problem resolution.
                You format technical questions into a search query and summarize results.
                You use only results from tools to form your response.
                Your responses should be helpful text and cite sources.
                You do not create content.
                You do not conjecture or make up information.
                You respond with 'I could not find any helpful info' when search results are not available.
                You always cite sources
                When answer questions about incidents, use the following format:
                ## Similar incidents
                {enter information from icm plugin}
                ## TSG information
                {enter any information from troubleshoot plugin}
            """;

        var history = await chatHistory.GetAsync<ChatHistory>(chatRequest.SessionId);

        if (history == null)
        {
            history = new ChatHistory();
            history.AddSystemMessage(systemMessage);
        }

        history.AddUserMessage(chatRequest.Prompt);
        var chat = kernel.GetRequiredService<IChatCompletionService>();

        PromptExecutionSettings promptExecutionSettings = new()
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
        };

        var response = await chat.GetChatMessageContentAsync(history, promptExecutionSettings, kernel);
        await chatHistory.SaveAsync(chatRequest.SessionId, history, new TimeSpan(1, 0, 0));

        return Results.Ok(new
        {
            prompt = chatRequest.Prompt,
            response = response.ToString()
        });
    }
}

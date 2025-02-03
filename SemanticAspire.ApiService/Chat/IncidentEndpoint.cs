using Azure;
using Azure.Search.Documents.Indexes;
using Azure.Security.KeyVault.Secrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
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
        var builder = Kernel.CreateBuilder();

        Uri searchEndpoint = new("https://srch-vzac3zroquyd4.search.windows.net");
        AzureKeyCredential searchCredential = new(secretClient.GetSecret("search-key").Value.Value);

        builder.Services.AddSingleton<SearchIndexClient>((_) => new SearchIndexClient(searchEndpoint, searchCredential));
        builder.Services.AddSingleton<IAzureSearchService, AzureSearchService>();

        builder.AddAzureOpenAIChatCompletion(
           "gpt-4",
           "https://aoai-vzac3zroquyd4.services.ai.azure.com/",
           secretClient.GetSecret("gp4-endpoint-key").Value.Value);

        builder.AddAzureOpenAITextEmbeddingGeneration(
           "text-embedding-ada-002",
          "https://aoai-vzac3zroquyd4.services.ai.azure.com/",
          secretClient.GetSecret("gp4-endpoint-key").Value.Value);

        builder.Plugins.AddFromType<TroubleshootPlugin>("SearchPlugin");
        Kernel kernel = builder.Build();

        var systemMessage =
            $$$"""
                You are Aioki, a helpful assisant for Azure IoT Operations problem resolution.
                You format technical questions into a search query and summarize results.
                You use only result from search to form your response.
                Your responses should be helpful text and cite sources.
                You do not create generative creative content.
                You do not conjecture or make up information.
                You respond with 'I could not find any helpful info' when search results are not available.
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

        return Results.Ok(new
        {
            prompt = chatRequest.Prompt,
            response = response.ToString()
        });
    }
}

using Azure;
using Azure.Search.Documents.Indexes;
using Azure.Security.KeyVault.Secrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using SemanticAspire.Plugins;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

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

        var arguments = new KernelArguments
        {
            ["searchFields"] = JsonSerializer.Serialize(new List<string> { "text_vector" }),
            ["search"] = "create icm",
            ["collection"] = "vector-tsg"
        };

        var promptTemplate = """
            {{search $search collection=$collection searchFields=$searchFields}}
            Write a summary of the provided text in the voice of a valley girl.
            Include citations to the relevant information where it is referenced in the response.
        """;

        var history = await chatHistory.GetAsync<ChatHistory>(chatRequest.SessionId);
        if (history == null)
        {
            history = new ChatHistory();
            history.AddSystemMessage("You help users investigate root cause for incidents", );
        }

        history.AddUserMessage(chatRequest.Prompt);
        var chat = kernel.GetRequiredService<IChatCompletionService>();

        var response = new StringBuilder();
        await foreach (var result in chat.GetStreamingChatMessageContentsAsync(history))
        {
            response.Append(result.Content);
        }

        // await chatHistory.SaveAsync(chatRequest.SessionId, history, new TimeSpan(1, 0, 0));

        return Results.Ok(new
        {
            prompt = chatRequest.Prompt,
            response = response.ToString()
        });
    }
}

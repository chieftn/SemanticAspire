using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Runtime.CompilerServices;
using System.Text;

namespace SemanticAspire.ApiService;

internal static class ChatEndpoint
{
    internal static WebApplication MapChatEndpoints(
       this WebApplication app)
    {
        var chat = app.MapGroup("api/chat");

        chat.MapPost(
            pattern: "/",
            handler: GetChatCompletionAsync);

        return app;
    }

    private static async Task<IResult> GetChatCompletionAsync(
        SecretClient client,
        ChatRequest chatRequest,
        [EnumeratorCancellation]
        CancellationToken cancellationToken
        )
    {
        var builder = Kernel.CreateBuilder();
        builder.AddAzureOpenAIChatCompletion(
           "gpt-4",
           "https://aoai-vzac3zroquyd4.services.ai.azure.com/",
           new AzureCliCredential());


        Kernel kernel = builder.Build();

        ChatHistory history = [];
        history.AddUserMessage(chatRequest.Prompt);

        var chat = kernel.GetRequiredService<IChatCompletionService>();

        var response = new StringBuilder();
        await foreach (var result in chat.GetStreamingChatMessageContentsAsync(history))
        {
            response.Append(result.Content);
        }

        return Results.Ok(new
        {
            prompt = chatRequest.Prompt,
            response = response.ToString()
        });
    }
}

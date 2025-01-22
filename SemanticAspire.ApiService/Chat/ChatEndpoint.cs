using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

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
       string prompt,
       CancellationToken cancellationToken)
    {
        var builder = Kernel.CreateBuilder();
        builder.AddAzureOpenAIChatCompletion(
           "gpt-4",
           "https://aoai-vzac3zroquyd4.services.ai.azure.com/",
           new AzureCliCredential());


        Kernel kernel = builder.Build();

        ChatHistory history = [];
        history.AddUserMessage("Hello, how are you?");

        var chat = kernel.GetRequiredService<IChatCompletionService>();
        var response = await chat.GetChatMessageContentAsync(
            history,
            kernel: kernel
        );

        return Results.Ok(new
        {
            prompt,
            response
        });
    }
}

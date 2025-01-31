using Azure.Security.KeyVault.Secrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using SemanticAspire.ApiService.Plugins;
using SemanticConsole.Plugins;
using System.Runtime.CompilerServices;
using System.Text;

namespace SemanticAspire.ApiService;

internal static class PretzelEndpoint
{
    internal static WebApplication MapPretzelEndpoints(
        this WebApplication app)
    {
        var chat = app.MapGroup("api/pretzels");

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
        builder.AddAzureOpenAIChatCompletion(
            "gpt-4",
            "https://aoai-vzac3zroquyd4.services.ai.azure.com/",
            secretClient.GetSecret("gp4-endpoint-key").Value.Value);

        builder.Plugins.AddFromType<PretzelStatistics>();
        builder.Plugins.AddFromType<MetriculonStatistics>();

        Kernel kernel = builder.Build();

        ChatCompletionAgent agentPretzel =
          new()
          {
              Name = "PretzelAgent",
              Instructions =
                  $$$"""
                    Your job is to assist a snack company improve the quality of their pretzels.
                    The company has two pretzel lines: A and B.

                    The quality is measured via three combined data points:
                    1. CrustHardness (crust hardness) measured via pushpin-omometer in units of crufts (CR) where higher is harder.
                    2. interior Sponginess measured via squishometer in units of charmins (CH) where lower is spongier.
                    3. Weight measured by scale in units of otters (OT) where higher is heavier.

                    Inputs for pretzel lines are
                    1. water temperature of yeast (measured in fahrenheit).
                    2. oven cooktime (measured in minutes).
                    3. cooling rack time (measured in minutes).

                    RULES:
                        Do not make up information.
                        Use metriculon statistics when comparing lines or suggesting improvements and show the work
                    """,
              Kernel = kernel,
              Arguments = new KernelArguments(new AzureOpenAIPromptExecutionSettings() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() })
          };

        var history = await chatHistory.GetAsync<ChatHistory>(chatRequest.SessionId);


        if (history == null)
        {
            history = new ChatHistory();
        }

        history.AddUserMessage(chatRequest.Prompt);
        var chat = kernel.GetRequiredService<IChatCompletionService>();

        var response = new StringBuilder();
        await foreach (ChatMessageContent result in agentPretzel.InvokeAsync(history))
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

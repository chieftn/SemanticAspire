using Azure.Security.KeyVault.Secrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using SemanticAspire.ApiService.Plugins;
using System.Runtime.CompilerServices;
using System.Text;

namespace SemanticAspire.ApiService
{
    internal static class ModelEndpoint
    {
        internal static WebApplication MapModelAgentEndpoints(
            this WebApplication app)
        {
            var chat = app.MapGroup("api/model");

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
        CancellationToken cancellationToken)
        {
            var builder = Kernel.CreateBuilder();
            builder.AddAzureOpenAIChatCompletion(
                "gpt-4",
                "https://aoai-vzac3zroquyd4.services.ai.azure.com/",
                secretClient.GetSecret("gp4-endpoint-key").Value.Value);

            builder.Plugins.AddFromType<EntityModelPlugin>();

            Kernel kernel = builder.Build();

            ChatCompletionAgent agentPretzel =
                new()
                {
                    Name = "ModelAgent",
                    Instructions =
                        $$$"""
                            Your users possess an "entity database" to track assets in their industrial workloads.
                            Example entities for a large scale bakery might include: 
                                1. Mixer
                                1. Proofer
                                1. Conveyer
                                1. Tensioner
                            Entities also have a relationships. Example:
                                1. Conveyer hasComponent Rollerset
                                1. Production line contains oven.
                           
                            You:
                                1. Look for clues about the type of entity the customer wants to examine.
                                1. Extract the entity types and query them in the database.
                                1. Answer questions about the entities and relationships.
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
}

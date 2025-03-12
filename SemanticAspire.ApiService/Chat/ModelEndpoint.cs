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
            builder.Plugins.AddFromType<EntityInstancePlugin>();

            Kernel kernel = builder.Build();

            ChatCompletionAgent agentModel =
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

            ChatCompletionAgent agentModelInstances =
              new()
              {
                  Name = "EntityInstanceAgent",
                  Instructions =
                      $$$"""
                            RULES
                            1. respond only in json, no markdown.

                            PREFACE
                            Your users possess an "entity instance database" to track assets in their industrial workloads.
                            This database supplies a listing of entity instances which are real world objects modeled by entities in a 
                            an entity model database.  You:
                            
                            1. figure out what entity the user is asking about.
                            1. lookup relevant information about entity instances.
                            1. use information about entity instances (e.g., property and time series to answer questions

                            You select the best way to respond to user questions:
                            1. TEXT: ideal to answer to questions in plain text. Use this method for simple questions and interactions.
                            1. GRAPH: used to visualize the model entities and relationships. Use this method in scenarios like:  'show me the graph' or 'show me the relationships'
                            1. TABLE: ideal to show comparisons between different entity instances.
                            1. CHART: ideal to show time series.

                            You always respond in JSON:
                            1. for TEXT, you provide format: { "text": "your response in markdown" }
                            1. for GRAPH, you provide format: { "graph": {  nodes: [{ id: value, name: value }, {id: value, name: value} ... {id: value, name: value}], edges: [{source: id, target: id }, {source: id, target: id} ... {source: id, target: id}] }} 
                            1. for TABLE you provide format { "table": { headers: [{header1}, {header2} ... {header}], rows: [{ header1: value, header2: value}, {header1: value, header2: value} ... {header1: value, header2: value}] } }
                            1. for CHART, you provide format: { "chart": { dataPoints [{dataPoint}, {dataPoint} ... {dataPoint}] } }

                          
                        """,
                  Kernel = kernel,
                  Arguments = new KernelArguments(new AzureOpenAIPromptExecutionSettings() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() })
              };

            var executionSettings = new AzureOpenAIPromptExecutionSettings()
            {
                ResponseFormat = "json_object"
            };

            var history = await chatHistory.GetAsync<ChatHistory>(chatRequest.SessionId);
            if (history == null)
            {
                history = new ChatHistory();
            }

            history.AddUserMessage(chatRequest.Prompt);
            var chat = kernel.GetRequiredService<IChatCompletionService>();

            var response = new StringBuilder();
            await foreach (ChatMessageContent result in agentModelInstances.InvokeAsync(history))
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

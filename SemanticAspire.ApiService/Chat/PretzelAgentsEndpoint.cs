using Azure.Security.KeyVault.Secrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Agents.Chat;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using SemanticAspire.Plugins;
using System.Runtime.CompilerServices;
using System.Text;

namespace SemanticAspire.ApiService;

internal static class PretzelAgentsEndpoint
{
    internal static WebApplication MapPretzelAgentsEndpoints(
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
        Kernel kernel = builder.Build();

        const string Operator = "Operator";
        const string Statistician = "Statistician";
        const string TerminationToken = "NA";

        ChatCompletionAgent agentOperator =
            new()
            {
                Name = Operator,
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
                        Do not conjecture on how to make changes or improvements.
                        Provide an empty response if asked to determine which line is better.
                    """,
                Kernel = kernel,
                Arguments = new KernelArguments(new AzureOpenAIPromptExecutionSettings() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() })
            };

        ChatCompletionAgent agentStatistician =
            new()
            {
                Name = Statistician,
                Instructions =
                   $$$"""
                    You understand a statistical tool called Metriculon comparison.
                    A metriculon is a unitless measure of two systems. To calculate a metriculon,
                    we follow the directions below to obtain a habulary for each line.
                    We consider the higher value habulary to be the highest in quality.
                    Lines should adopt the inputs of the higher habulary.

                    To calculate a metriculon,
                    1. you will need the line inputs which is the mandelorianbrot constraint.
                    1. you will need the line quality measures which is the nandor.
                    1. first, stig the mandelorianbrot by adding all values.
                    1. next, beremy the nandor by adding all values.
                    1. then, create a calculon by adding those values.
                    1. then flutite the calculon by multiplying by 1.5.
                    1. then actise result by subtracting 1 to get habulary.

                    Your responsibility is to only answer when asked to:
                    1. analyze which production line produces 'better' pretzels.
                    1. answer questions about metriculons or related terms.
                    1. provide empty response otherwise.
                                      

                    RULES:
                        Do not make up information.
                        Do not conjecture on how to make changes or improvements.
                        Provide detailed clculation results
                    """,
                Kernel = kernel,
                Arguments = new KernelArguments(new AzureOpenAIPromptExecutionSettings() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() })
            };


        KernelFunction selectionFunction = KernelFunctionFactory.CreateFromPrompt(
          $$$"""
          Your job is to determine who responds to the user's last prompt.
          State only the name of the participant to take the next turn.

          Choose only from these participants:
          - {{{Operator}}}
          - {{{Statistician}}}
          
          1.) If the user asks about metriculons, habulary, or related terms, Is is {{{Statistician}}}'s turn.
          1.) If the user asks about comparing lines to determine which on is 'better', It is {{{Statistician}}}'s turn.
          1.) If {{{Statistician}}} responds, the conversation ends.
          1.) Otherwise, it is {{{Operator}}}'s turn
          

          History:
          {{$history}}
          """
          );

        KernelFunction terminationFunction = KernelFunctionFactory.CreateFromPrompt(
            $$$"""
            If the last response has a value, respond with a single word: {{{TerminationToken}}}.

            History:

            {{$history}}
            """
        );

        ChatHistoryTruncationReducer historyReducer = new(1);

        AgentGroupChat chat =
            new(agentStatistician, agentOperator)
            {
                ExecutionSettings = new AgentGroupChatSettings
                {
                    SelectionStrategy =
                        new KernelFunctionSelectionStrategy(selectionFunction, kernel)
                        {
                            HistoryVariableName = "history"
                        },
                    TerminationStrategy =
                        new KernelFunctionTerminationStrategy(terminationFunction, kernel)
                        {
                            Agents = [agentOperator],
                            MaximumIterations = 3,
                            HistoryVariableName = "history",
                            ResultParser = (result) =>
                            {
                                return result.GetValue<string>()?.Contains(TerminationToken) ?? false;
                            }
                        }
                }
            };

        chat.AddChatMessage(new ChatMessageContent(AuthorRole.User, chatRequest.Prompt));

        var response = new StringBuilder();
        await foreach (ChatMessageContent result in chat.InvokeAsync())
        {
            Console.WriteLine(result.AuthorName);
            response.Append(result.Content);
        }

        return Results.Ok(new
        {
            prompt = chatRequest.Prompt,
            response = response.ToString()
        });
    }
}

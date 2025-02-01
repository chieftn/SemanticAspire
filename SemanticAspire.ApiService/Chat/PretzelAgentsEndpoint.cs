using Azure.Security.KeyVault.Secrets;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Agents.Chat;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using SemanticConsole.Plugins;
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
                    - Do not make up information.
                    - Do not conjecture on how to make changes or improvements.
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
                    Otherwise provide an empty response
                    """,
                Kernel = kernel,
                Arguments = new KernelArguments(new AzureOpenAIPromptExecutionSettings() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() })
            };

        KernelFunction terminationFunction =
             AgentGroupChat.CreatePromptFunctionForStrategy(
                 $$$"""
                Examine the RESPONSE and determine whether the content has been deemed satisfactory.
                If content is satisfactory, respond with a single word without explanation: {{{TerminationToken}}}.
                If specific suggestions are being provided, it is not satisfactory.
                If no correction is suggested, it is satisfactory.

                RESPONSE:
                {{$lastmessage}}
                """,
                 safeParameterNames: "lastmessage");
        ChatHistoryTruncationReducer historyReducer = new(1);

        AgentGroupChat chat =
            new(agentStatistician, agentOperator)
            {
                ExecutionSettings = new AgentGroupChatSettings
                {
                    TerminationStrategy =
                        new KernelFunctionTerminationStrategy(terminationFunction, kernel)
                        {
                            Agents = [agentOperator],
                            MaximumIterations = 3,
                            ResultParser = (result) => result.GetValue<string>()?.Length > 0 ? true : false
                        }
                }
            };

        chat.AddChatMessage(new ChatMessageContent(AuthorRole.User, chatRequest.Prompt));

        var response = new StringBuilder();
        await foreach (ChatMessageContent result in chat.InvokeAsync())
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = result.AuthorName switch
            {
                Operator => ConsoleColor.Red,
                Statistician => ConsoleColor.Blue,
                _ => Console.ForegroundColor
            };

            Console.WriteLine(result.Content);
            response.Append(result.Content);
        }

        return Results.Ok(new
        {
            prompt = chatRequest.Prompt,
            response = response.ToString()
        });
    }
}

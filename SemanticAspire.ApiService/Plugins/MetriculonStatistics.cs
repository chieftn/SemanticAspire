using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using System.ComponentModel;
using System.Text;

namespace SemanticAspire.ApiService.Plugins;

public class MetriculonStatistics
{
    private static string StatisticsAgent = $$$"""
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

        RULES:
            Explain the calculation as you perform it.
            Do not make up information.
            Do not conjecture on how to make changes or improvements.
        """;

    [KernelFunction("production_line_comparison")]
    [Description("Describes and calculates the better of two production lines")]
    public async Task<string> GetMetriculonComparison(Kernel kernel, string lineName1, string lineName2)
    {
        ChatCompletionAgent agentStatistician = new()
        {
            Name = "StatisticsAgent",
            Instructions = StatisticsAgent,
            Kernel = kernel,
            Arguments = new KernelArguments(new AzureOpenAIPromptExecutionSettings() { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() })
        };

        ChatHistory chat = [];
        chat.Add(new ChatMessageContent(AuthorRole.User, $"compare line {lineName1} against line {lineName2}"));

        var response = new StringBuilder();
        await foreach (ChatMessageContent result in agentStatistician.InvokeAsync(chat))
        {
            response.Append(result.Content);
        }

        return response.ToString();
    }
}

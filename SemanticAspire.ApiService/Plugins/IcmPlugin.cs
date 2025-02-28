using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Embeddings;
using SemanticAspire.ApiService;
using System.ComponentModel;

namespace SemanticAspire.Plugins;

class IcmPlugin
{
    private readonly ITextEmbeddingGenerationService _textEmbeddingGenerationService;
    private readonly IChatCompletionService _chatCompletionService;
    private readonly IAzureSearchService<IcmDataModel> _searchService;

    public IcmPlugin(
        ITextEmbeddingGenerationService textEmbeddingGenerationService,
        IChatCompletionService chatCompletionService,
        IAzureSearchService<IcmDataModel> searchService)
    {
        this._textEmbeddingGenerationService = textEmbeddingGenerationService;
        this._chatCompletionService = chatCompletionService;
        this._searchService = searchService;
    }

    [KernelFunction("Azure_IoT_Incident")]
    [Description("provides information about past incidents (icms) for possible answers to current problems.")]
    public async Task<string?> SearchAsync(
        string query,
        CancellationToken cancellationToken = default)
    {
        var searchFields = new List<string> { "text_vector" };
        var collection = "vector-icm-clusters3";

        ReadOnlyMemory<float> embedding = await this._textEmbeddingGenerationService.GenerateEmbeddingAsync(query, cancellationToken: cancellationToken);
        var results = await this._searchService.SearchAsync(
            collection,
            embedding,
            query,
            "vector-icm-clusters3-semantic-configuration",
            searchFields,
            cancellationToken);

        var formattedResult = new System.Text.StringBuilder();
        foreach (var result in results)
        {
            formattedResult.AppendLine(
                $"""
                    Incident:
                    ID: [{result.IncidentId}](https://portal.microsofticm.com/imp/v5/incidents/details/{result.IncidentId})
                    Title: {result.Title}
                    Type: {result.IncidentType}
                    Description: {result.Chunk}
                    Mitigation: {result.Mitigation}
                    Resolution: {result.HowFixed}
                    TSG: {result.TsgId}
                """
            );
        }

        return formattedResult.ToString();
    }
}

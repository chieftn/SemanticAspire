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
        var collection = "vector-icmjson";

        ReadOnlyMemory<float> embedding = await this._textEmbeddingGenerationService.GenerateEmbeddingAsync(query, cancellationToken: cancellationToken);

        // Perform search
        var results = await this._searchService.SearchAsync(collection, embedding, searchFields, cancellationToken) ?? null;

        var formattedResult = new System.Text.StringBuilder();
        foreach (var result in results)
        {
            formattedResult.AppendLine(
                $"""
                    Incident: {result.IncidentId}
                    Incident type: {result.IncidentType}
                    Incident description: {result.Chunk}
                    Incident mitigation: {result.Mitigation}
                    Incident resolution: {result.HowFixed}
                """
            );
        }

        return formattedResult.ToString();
    }
}

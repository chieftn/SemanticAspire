using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Embeddings;
using SemanticAspire.ApiService;
using System.ComponentModel;

namespace SemanticAspire.Plugins;

class TroubleshootPlugin
{
    private readonly ITextEmbeddingGenerationService _textEmbeddingGenerationService;
    private readonly IAzureSearchService _searchService;

    public TroubleshootPlugin(
        ITextEmbeddingGenerationService textEmbeddingGenerationService,
        IAzureSearchService searchService)
    {
        this._textEmbeddingGenerationService = textEmbeddingGenerationService;
        this._searchService = searchService;
    }

    [KernelFunction("Azure_IoT_Knowledge_Base")]
    [Description("provides authoritivate search results for Azure IoT Operations to help troubleshoot problems")]
    public async Task<string> SearchAsync(
        string query,
        CancellationToken cancellationToken = default)
    {
        var searchFields = new List<string> { "text_vector" };
        var collection = "vector-tsg";

        ReadOnlyMemory<float> embedding = await this._textEmbeddingGenerationService.GenerateEmbeddingAsync(query, cancellationToken: cancellationToken);

        // Perform search
        var result = await this._searchService.SearchAsync(collection, embedding, searchFields, cancellationToken) ?? string.Empty;
        return result;
    }
}

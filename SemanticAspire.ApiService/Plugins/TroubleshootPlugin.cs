using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Embeddings;
using SemanticAspire.ApiService;

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

    [KernelFunction("Search")]
    public async Task<string> SearchAsync(
        string query,
        string collection,
        List<string>? searchFields = null,
        CancellationToken cancellationToken = default)
    {
        // Convert string query to vector
        ReadOnlyMemory<float> embedding = await this._textEmbeddingGenerationService.GenerateEmbeddingAsync(query, cancellationToken: cancellationToken);

        // Perform search
        var result = await this._searchService.SearchAsync(collection, embedding, searchFields, cancellationToken) ?? string.Empty;
        return result;
    }
}

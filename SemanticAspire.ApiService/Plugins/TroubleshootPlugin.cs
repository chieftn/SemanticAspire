using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Embeddings;
using SemanticAspire.ApiService;
using System.ComponentModel;

namespace SemanticAspire.Plugins;

class TroubleshootPlugin
{
    private readonly ITextEmbeddingGenerationService _textEmbeddingGenerationService;
    private readonly IChatCompletionService _chatCompletionService;
    private readonly IAzureSearchService<TroubleshootDataModel> _searchService;

    public TroubleshootPlugin(
        ITextEmbeddingGenerationService textEmbeddingGenerationService,
        IChatCompletionService chatCompletionService,
        IAzureSearchService<TroubleshootDataModel> searchService)
    {
        this._textEmbeddingGenerationService = textEmbeddingGenerationService;
        this._chatCompletionService = chatCompletionService;
        this._searchService = searchService;
    }

    [KernelFunction("Azure_IoT_Knowledge_Base")]
    [Description("provides authoritivate search results for Azure IoT Operations to help troubleshoot problems")]
    public async Task<string?> SearchAsync(
        string query,
        CancellationToken cancellationToken = default)
    {
        var searchFields = new List<string> { "text_vector" };
        var collection = "vector-tsgmd";

        ReadOnlyMemory<float> embedding = await this._textEmbeddingGenerationService.GenerateEmbeddingAsync(query, cancellationToken: cancellationToken);

        // Perform search
        var results = await this._searchService.SearchAsync(collection, embedding, query, searchFields, cancellationToken) ?? null;

        var formattedResult = new System.Text.StringBuilder();
        foreach (var result in results)
        {
            formattedResult.AppendLine(
                $"""
                    # Search Result
                    {result.Chunk}
                    # Source
                    {result.Title}
                """
            );
        }

        return formattedResult.ToString();
    }
}

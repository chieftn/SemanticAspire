using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;

namespace SemanticAspire.ApiService;

interface IAzureSearchService<T> where T : BaseModel
{
    Task<List<T>> SearchAsync(
        string collectionName,
        ReadOnlyMemory<float> vector,
        string query,
        string semanticConfiguration,
        List<string>? searchFields = null,
        CancellationToken cancellationToken = default);
}

class AzureSearchService<T> : IAzureSearchService<T> where T : BaseModel
{
    private readonly List<string> _defaultVectorFields = new() { "text_vector" };

    private readonly SearchIndexClient _indexClient;

    public AzureSearchService(SearchIndexClient indexClient)
    {
        this._indexClient = indexClient;
    }

    public async Task<List<T>> SearchAsync(
        string collectionName,
        ReadOnlyMemory<float> vector,
        string query,
        string? semanticConfiguration = null,
        List<string>? searchFields = null,
        CancellationToken cancellationToken = default)
    {
        // Get client for search operations
        SearchClient searchClient = this._indexClient.GetSearchClient(collectionName);

        // Use search fields passed from Plugin or default fields configured in this class.
        List<string> fields = searchFields is { Count: > 0 } ? searchFields : this._defaultVectorFields;

        // Configure request parameters
        VectorizedQuery vectorQuery = new(vector);
        fields.ForEach(field => vectorQuery.Fields.Add(field));

        SearchOptions searchOptions = new()
        {
            VectorSearch = new()
            {
                Queries = { vectorQuery }
            },
            SemanticSearch = new SemanticSearchOptions()
            {
                SemanticConfigurationName = semanticConfiguration,
                QueryCaption = new QueryCaption(QueryCaptionType.Extractive),
                QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive),
            }
        };

        // Perform search request
        Response<SearchResults<T>> response = await searchClient.SearchAsync<T>(query, searchOptions, cancellationToken);
        HashSet<string> idSet = response.Value.SemanticSearch.Answers.Select(item => item.Key).ToHashSet();

        List<T> results = new();
        await foreach (SearchResult<T> result in response.Value.GetResultsAsync())
        {
            if (idSet.Contains(result.Document.ChunkId))
            {
                results.Add(result.Document);
            }
        }

        return results;
    }
}
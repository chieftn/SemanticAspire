using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;

namespace SemanticAspire.ApiService;

interface IAzureSearchService
{
    Task<string?> SearchAsync(
        string collectionName,
        ReadOnlyMemory<float> vector,
        List<string>? searchFields = null,
        CancellationToken cancellationToken = default);
}

class AzureSearchService : IAzureSearchService
{
    private readonly List<string> _defaultVectorFields = new() { "text_vector" };

    private readonly SearchIndexClient _indexClient;

    public AzureSearchService(SearchIndexClient indexClient)
    {
        this._indexClient = indexClient;
    }

    public async Task<string?> SearchAsync(
        string collectionName,
        ReadOnlyMemory<float> vector,
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

        SearchOptions searchOptions = new() { VectorSearch = new() { Queries = { vectorQuery } } };

        // Perform search request
        Response<SearchResults<DataModel>> response = await searchClient.SearchAsync<DataModel>(searchOptions, cancellationToken);

        List<DataModel> results = new();

        // Collect search results
        await foreach (SearchResult<DataModel> result in response.Value.GetResultsAsync())
        {
            results.Add(result.Document);
        }

        // Return text from first result.
        // In real applications, the logic can check document score, sort and return top N results
        // or aggregate all results in one text.
        // The logic and decision which text data to return should be based on business scenario.
        return results.FirstOrDefault()?.Chunk;
    }
}
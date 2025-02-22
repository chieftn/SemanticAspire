﻿using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;

namespace SemanticAspire.ApiService;

interface IAzureSearchService<T>
{
    Task<List<T>> SearchAsync(
        string collectionName,
        ReadOnlyMemory<float> vector,
        List<string>? searchFields = null,
        CancellationToken cancellationToken = default);
}

class AzureSearchService<T> : IAzureSearchService<T>
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
        Response<SearchResults<T>> response = await searchClient.SearchAsync<T>(searchOptions, cancellationToken);

        List<T> results = new();

        // Collect search results
        await foreach (SearchResult<T> result in response.Value.GetResultsAsync())
        {
            results.Add(result.Document);
        }

        return results;
    }
}
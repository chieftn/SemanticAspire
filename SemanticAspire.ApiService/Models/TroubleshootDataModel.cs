using System.Text.Json.Serialization;

class TroubleshootDataModel
{
    [JsonPropertyName("chunk_id")]
    public string? ChunkId { get; set; }

    [JsonPropertyName("parent_id")]
    public string? ParentId { get; set; }

    [JsonPropertyName("chunk")]
    public string? Chunk { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("vector")]
    public ReadOnlyMemory<float> Vector { get; set; }
}

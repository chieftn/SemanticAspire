using System.Text.Json.Serialization;

public class BaseModel
{
    [JsonPropertyName("chunk_id")]
    public string ChunkId { get; set; }

    [JsonPropertyName("chunk")]
    public string Chunk { get; set; }

    [JsonPropertyName("parent_id")]
    public string? ParentId { get; set; }
}


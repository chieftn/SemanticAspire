using System.Text.Json.Serialization;

public class IcmDataModel
{
    [JsonPropertyName("chunk_id")]
    public string ChunkId { get; set; }

    [JsonPropertyName("chunk")]
    public string Chunk { get; set; }
    public string TsgId { get; set; }
    public string Title { get; set; }
    public string Mitigation { get; set; }
    public string IncidentType { get; set; }
    public string HowFixed { get; set; }
    public int IncidentId { get; set; }
}

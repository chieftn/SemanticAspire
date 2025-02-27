using System.Text.Json.Serialization;

class TroubleshootDataModel : BaseModel
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("vector")]
    public ReadOnlyMemory<float> Vector { get; set; }
}

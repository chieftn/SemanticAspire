namespace SemanticAspire.ApiService.Models;

public class TimeSeriesData
{
    public string Timestamp { get; set; }
    public double Value { get; set; }
}

public class EntityInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int EntityType { get; set; }
    public Dictionary<string, double> Properties { get; set; }
    public Dictionary<string, List<TimeSeriesData>> TimeSeries { get; set; }
}

using System.Text.Json.Serialization;
public class Flight
{
    [JsonPropertyName("FlightNumber")]
    public string? FlightNumber { get; set; }

    [JsonPropertyName("Departure")]
    public string? Departure { get; set; }

    [JsonPropertyName("Destination")]
    public string? Destination { get; set; }

    [JsonPropertyName("TimeDeparture")]
    public DateTime? TimeDeparture { get; set; }

    [JsonPropertyName("TimeArrival")]
    public DateTime? TimeArrival { get; set; }

    [JsonPropertyName("Duration")]
    public double? Duration { get; set; }

    [JsonPropertyName("Aircraft")]
    public Aircraft? Aircraft { get; set; }
}

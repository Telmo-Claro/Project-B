using System.Text.Json.Serialization;

public class Flight
{
    [JsonPropertyName("FlightNumber")]
    public required string FlightNumber { get; set; }

    [JsonPropertyName("Departure")]
    public required string Departure { get; set; }

    [JsonPropertyName("Destination")]
    public required string Destination { get; set; }

    [JsonPropertyName("Date")]
    public required DateTime Date { get; set; }

    [JsonPropertyName("TimeDeparture")]
    public required TimeSpan TimeDeparture { get; set; }

    [JsonPropertyName("TimeArrival")]
    public required TimeSpan TimeArrival { get; set; }

    [JsonPropertyName("Duration")]
    public required TimeSpan Duration { get; set; }

    [JsonPropertyName("SelectedTimeslots")]
    public required List<TimeSpan> SelectedTimeslots { get; set; } = new List<TimeSpan>();

    [JsonPropertyName("Country")]
    public required string Country { get; set; }

    [JsonPropertyName("Aircraft")]
    public required Aircraft Aircraft { get; set; }

    [JsonPropertyName("Status")]
    public required string Status { get; set; }

    [JsonPropertyName("Price")]
    public required int Price { get; set; }
}

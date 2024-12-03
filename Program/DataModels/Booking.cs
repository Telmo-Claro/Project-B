using System.Text.Json.Serialization;

public class Booking
{
    [JsonPropertyName("BookingCode")]
    public string? BookingCode { get; set; }

    [JsonPropertyName("FlightNumber")]
    public string? FlightNumber { get; set; }

    [JsonPropertyName("Departure")]
    public string? Departure { get; set; }

    [JsonPropertyName("Destination")]
    public string? Destination { get; set; }

    [JsonPropertyName("Date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("TimeDeparture")]
    public TimeSpan TimeDeparture { get; set; }

    [JsonPropertyName("TimeArrival")]
    public TimeSpan TimeArrival { get; set; }

    [JsonPropertyName("Seats")]
    public List<Seat>? Seats { get; set; }

    [JsonPropertyName("SpecialExperience")]
    public TimeSpan? SpecialExperience { get; set; }

    [JsonPropertyName("Price")]
    public int? Price { get; set; }

    public override string ToString()
    {
        return $"Booking Code: {BookingCode}\n" +
                $"Flight Number: {FlightNumber}\n" +
                $"Departure: {Departure}\n" +
                $"Destination: {Destination}\n" +
                $"Date: {Date.ToShortDateString()}\n" +
                $"TimeDeparture: {TimeDeparture}\n" +
                $"TimeArrival: {TimeArrival}\n" +
                $"Seats: {string.Join(", ", Seats)}\n" +
                $"Special Experience: {(SpecialExperience is null ? "Not Booked" : $"{SpecialExperience}")}\n" +
                $"Price: €{Price}";
    }
}


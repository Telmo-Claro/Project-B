using System.Text.Json.Serialization;
public class Aircraft
{
    [JsonPropertyName("Name")]
    public string? Name { get; }

    [JsonPropertyName("TotalSeats")]
    public int TotalSeats { get; }

    [JsonPropertyName("LeftSeats")]
    public int LeftSeats { get; }

    [JsonPropertyName("BookedSeats")]
    public List<Seat> BookedSeats { get; set; }

    public Aircraft(int totalSeats, string? name)
    {
        TotalSeats = totalSeats;
        LeftSeats = totalSeats;
        Name = name;
        BookedSeats = new List<Seat>();
    }

    public override string? ToString()
    {
        return Name;
    }
}
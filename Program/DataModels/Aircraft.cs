using System.Text.Json.Serialization;
public class Aircraft
{
    [JsonPropertyName("Name")]
    public string Name { get; }

    [JsonPropertyName("TotalSeats")]
    public int TotalSeats { get; }

    [JsonPropertyName("LeftSeats")]
    public int LeftSeats { get; }

    public Aircraft(int totalSeats, string name)
    {
        TotalSeats = totalSeats;
        LeftSeats = totalSeats;
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

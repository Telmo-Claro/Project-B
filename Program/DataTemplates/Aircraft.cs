using System.Text.Json.Serialization;
public class Aircraft
{
    public int TotalSeats { get; }
    public int LeftSeats { get; }

    public Aircraft(int totalSeats)
    {
        TotalSeats = totalSeats;
        LeftSeats = totalSeats;
    }
    [JsonConstructor]
    public Aircraft(int totalSeats, int leftSeats)
    {
        TotalSeats = totalSeats;
        LeftSeats = leftSeats;
    }
}

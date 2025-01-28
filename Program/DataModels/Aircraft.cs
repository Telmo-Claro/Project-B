using System.Runtime.Serialization;
using System.Text.Json.Serialization;
public class Aircraft
{
    [JsonPropertyName("Name")]
    public string? Name { get; }

    [JsonPropertyName("TotalSeats")]
    public int TotalSeats { get; }

    [JsonPropertyName("LeftSeats")]
    public int LeftSeats { get; private set; }

    [JsonPropertyName("BookedSeats")]
    public List<Seat> BookedSeats { get; set; }

    [JsonPropertyName("ValidSeats")]
    public List<string> ValidSeats { get; set; }

    [JsonPropertyName("PlaneOverview")]
    public string PlaneOverview { get; set; }

    [JsonPropertyName("RestOverview")]
    public string RestOverview { get; set; }

    public Aircraft(int totalSeats, string? name)
    {
        TotalSeats = totalSeats;
        LeftSeats = totalSeats;
        Name = name;
        BookedSeats = new List<Seat>();
        ValidSeats = new List<string>();
        PlaneOverview = string.Empty;
    }


    public override string? ToString()
    {
        return Name;
    }

    public void SeatCountMinus()
    {
        LeftSeats--;
    }

     public void SeatCountPlus()
    {
        LeftSeats++;
    }
}
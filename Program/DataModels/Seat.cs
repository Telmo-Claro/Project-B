using System.Diagnostics;
using System.Text.Json.Serialization;

public class Seat
{
    [JsonPropertyName("SeatId")]
    public string SeatId { get; set; }

    [JsonPropertyName("Type")]
    public string Type { get; set; }

    [JsonPropertyName("Price")]
    public int Price { get; set; }
    public Seat(string seatId, string type, int price)
    {
        SeatId = seatId;
        Type = type;
        Price = price;
    }

    public int GetPrice()
    {
        switch (Type)
        {
            case "First Class":
                return 200;
            case "Business Class":
                return 100;
            case "Extra leg room":
                return 20;
            case "Economy":
                return 0;
            default:
                return 8;
        }
    }
    public override string ToString()
    {
        return $"{SeatId}";
    }
}

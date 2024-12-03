using System;
using System.Diagnostics;
using System.Text.Json.Serialization;

public class Seat : IEquatable<Seat>
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
    public bool Equals(Seat? seat)
    {
        if (seat is null) { return false; }
        if (seat.SeatId == this.SeatId) { return true; }
        return false;
    }

    public override bool Equals(object obj)
    {
        if (obj is Seat seat)
        {
            return Equals(seat);
        }
        return false;
    }
    public override string ToString()
    {
        return $"{SeatId}";
    }
}

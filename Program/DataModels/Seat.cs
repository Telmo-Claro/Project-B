using System.Diagnostics;

public class Seat
{
    public string SeatId {  get; set; }
    public string Type { get; set; }
    public Seat(string iD, string type)
    {
        SeatId = iD;
        Type = type;
    }

    public int GetPrice()
    {
        switch (SeatId)
        {
            case "First class":
                return 200;
            case "Business class":
                return 100;
            case "Extra leg room":
                return 20;
            case "Economy":
                return 0;
            default:
                return 0;
        }
    }
    public override string ToString()
    {
        return $"{SeatId} - {Type} - ${GetPrice()}";
    }
}

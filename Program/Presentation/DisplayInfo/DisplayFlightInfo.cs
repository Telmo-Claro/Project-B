public static class DisplayFlightInfo
{
    public static void FlightInfo(Flight flight)
    {
        Console.Clear();
        Console.WriteLine("---------------- TRENLINES -----------------");
        Console.WriteLine($"Flight number: {flight.FlightNumber}");
        Console.WriteLine($"Departure: {flight.Departure}");
        Console.WriteLine($"Destination: {flight.Destination}");
        Console.WriteLine($"Date: {flight.Date}");
        Console.WriteLine($"Time Departure: {flight.TimeDeparture}");
        Console.WriteLine($"Time Arrival: {flight.TimeArrival}");
        Console.WriteLine("--------------------------------------------");
    }
}
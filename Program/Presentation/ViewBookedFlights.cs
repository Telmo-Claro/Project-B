using Program.DataModels;

public static class ViewBookedFlights
{
    public static void PrintBookedFlight(List<Flight> bookedFlights)
    {
        int i = 1;
        Console.Clear();
        foreach (Flight flight in bookedFlights)
        {
            Console.WriteLine(@$"Flight: {i}
Flight number: {flight.FlightNumber}
Departure: {flight.Departure}
Destination: {flight.Destination}
Date: {flight.Date}
Aircraft name: {flight.Aircraft.Name}

");
            i++;
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}
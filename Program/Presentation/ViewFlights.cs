static class ViewFlights
{
    private static readonly List<Flight> _flights = FlightDataRW.ReadJson();

    private static string SpacesAdd(string str, string header)
    {
        if (str.Length < header.Length)
        {
            return $"{str}{new string(' ', header.Length - str.Length)}";
        }
        else { return str ; }
    }
    private static string FlightInfo(Flight flight)
    {
        return $"{SpacesAdd(flight.FlightNumber, "FlightNumber")}|{SpacesAdd(flight.Departure, "Departure")}|{SpacesAdd(flight.Destination, "Destination")}|{flight.Date.ToShortDateString()}|{flight.TimeDeparture}     |{flight.TimeArrival}   |{flight.Duration}|{SpacesAdd(flight.Country, "    Country    ")}|{SpacesAdd(flight.Aircraft.ToString(), "   Aircraft ")} |{SpacesAdd(flight.Status, "Status")}";
    }
    public static void View()
    {
        if (_flights.Count > 11)
        {
            for (int i = 0; i < 12; i++)
            {
                 Console.WriteLine(FlightInfo(_flights[i]));
            }
        }
        else
        {
            for (int i = 0; i < _flights.Count; i++)
            {
                Console.WriteLine(FlightInfo(_flights[i]));
            }
        }
    }
    public static void View(int page)
    {
        int IndexEnd = _flights.Count;
        int IndexStart = (page - 1) * 12;
        if (_flights.Count > 11)
        {
            if (IndexEnd - IndexStart < 12)
            {
                for (int i = IndexStart; i < IndexEnd - IndexStart; i++)
                {
                    Console.WriteLine(FlightInfo(_flights[i]));
                }
            }
            else
            {
                for (int i = IndexStart; i < 12 + IndexStart; i++)
                {
                    Console.WriteLine(FlightInfo(_flights[i]));
                }
            }
            
        }
        else
        {
            for (int i = 0; i < _flights.Count; i++)
            {
                Console.WriteLine(FlightInfo(_flights[i]));
            }
        }
    }
}
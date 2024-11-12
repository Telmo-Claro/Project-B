public static class ViewFlights
{
    private static readonly List<Flight> _flights = FlightDataRW.ReadJson();

    private static string? SpacesAdd(string? str, string header)
    {
        if (str.Length < header.Length)
        {
            return $"{str}{new string(' ', header.Length - str.Length)}";
        }
        else { return str ; }
    }
    private static string FlightInfo(Flight flight)
    {
        return $"{SpacesAdd(flight.FlightNumber, "FlightNumber")}|{SpacesAdd(flight.Departure, "Departure")}|{SpacesAdd(flight.Destination, "Destination")}|{flight.Date.ToShortDateString()}|{flight.TimeDeparture}     |{flight.TimeArrival}   |{flight.Duration}|{SpacesAdd(flight.Country, "    Country    ")}|{SpacesAdd(flight.Aircraft.ToString(), "   Aircraft ")} | {SpacesAdd("€"+flight.Price.ToString(), "Price")} |{SpacesAdd(flight.Status, "Status")}";
    }
    public static void View(int page)
    {
        int IndexEnd = _flights.Count;
        int IndexStart = (page - 1) * 12;
        if (_flights.Count > 11)
        {
            if (IndexEnd - IndexStart < 12)
            {
                for (int i = IndexStart; i < IndexEnd; i++)
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
    public static void View(int page, string? location, string? date)
    {
        List<Flight> flights = new List<Flight>();
        foreach (var flight in _flights)
        {
            if (flight.Destination == location && date == "")
            {
                flights.Add(flight);
            }
            else if (flight.Date.ToShortDateString() == date && location == "")
            {
                flights.Add(flight);
            }
            else if (flight.Date.ToShortDateString() == date && location == flight.Destination)
            {
                flights.Add(flight);
            }
        }

        int IndexEnd = flights.Count;
        int IndexStart = (page - 1) * 12;
        if (flights.Count > 11)
        {
            if (IndexEnd - IndexStart < 12)
            {
                for (int i = IndexStart; i < IndexEnd; i++)
                {
                    Console.WriteLine(FlightInfo(flights[i]));
                }
            }
            else
            {
                for (int i = IndexStart; i < 12 + IndexStart; i++)
                {
                    Console.WriteLine(FlightInfo(flights[i]));
                }
            }

        }
        else
        {
            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine(FlightInfo(flights[i]));
            }
        }
    }
}
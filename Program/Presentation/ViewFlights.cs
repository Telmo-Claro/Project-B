public static class ViewFlights
{
    // public static List<Flight> _flights = FlightDataRW.ReadJson();
    private static List<Flight> _flights = ViewUpdatedFlights.UpdateFlights();
    
    private static void UpdateFlights()
    {
        _flights = ViewUpdatedFlights.UpdateFlights();
    }

    private static string SpacesAdd(string str, string header)
    {
        if (str.Length < header.Length)
        {
            return $"{str}{new string(' ', header.Length - str.Length)}";
        }
        else { return str; }
    }
    private static string FlightInfo(Flight flight)
    {
        return $"{SpacesAdd(flight.FlightNumber, "FlightNumber")}|{SpacesAdd(flight.Departure, "Departure")}|{SpacesAdd(flight.Destination, "Destination")}|{flight.Date.ToShortDateString()}|{flight.TimeDeparture}     |{flight.TimeArrival}   |{flight.Duration}|{SpacesAdd(flight.Country, "    Country    ")}|{SpacesAdd(flight.Aircraft.ToString(), "   Aircraft ")} | {SpacesAdd("€" + flight.Price.ToString(), "Price")} |{SpacesAdd(flight.Status, "Status")}";
    }
    public static void View(int page)
    {
        UpdateFlights();
        int indexEnd = _flights.Count;
        int indexStart = (page - 1) * 12;
        if (_flights.Count > 11)
        {
            if (indexEnd - indexStart < 12)
            {
                for (int i = indexStart; i < indexEnd; i++)
                {
                    Console.WriteLine(FlightInfo(_flights[i]));
                }
            }
            else
            {
                for (int i = indexStart; i < 12 + indexStart; i++)
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
        UpdateFlights();
        List<Flight> flights = new List<Flight>();
        foreach (var flight in _flights)
        {
            if (flight.Destination.ToLower() == location.ToLower() && date == "")
            {
                flights.Add(flight);
            }
            else if (flight.Date.ToShortDateString() == date && location == "")
            {
                flights.Add(flight);
            }
            else if (flight.Date.ToShortDateString() == date && location.ToLower() == flight.Destination.ToLower())
            {
                flights.Add(flight);
            }
            else if (date == "" && location == "")
            {
                flights.Add(flight);
            }
        }

        int indexEnd = flights.Count;
        int indexStart = (page - 1) * 12;
        if (flights.Count > 11)
        {
            if (indexEnd - indexStart < 12)
            {
                for (int i = indexStart; i < indexEnd; i++)
                {
                    Console.WriteLine(FlightInfo(flights[i]));
                }
            }
            else
            {
                for (int i = indexStart; i < 12 + indexStart; i++)
                {
                    Console.WriteLine(FlightInfo(flights[i]));
                }
            }

        }
        else if (flights.Count < 1)
        {
            Console.WriteLine("There are no flights with the given data.");
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

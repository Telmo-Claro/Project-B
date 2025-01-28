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
                    if (_flights[i].Date.Date == DateTime.Today.AddDays(1)) // check if the flight leaves tomorrow
                    {
                        _flights[i].Price = (int)(_flights[i].Price * 0.1); // Apply 25% discount
                    }
                    Console.WriteLine(FlightInfo(_flights[i]));
                }
            }
            else
            {
                for (int i = indexStart; i < 12 + indexStart; i++)
                {
                    if (_flights[i].Date.Date == DateTime.Today.AddDays(1)) // check if the flight leaves tomorrow
                    {
                        _flights[i].Price = (int)(_flights[i].Price * 0.1); // Apply 25% discount
                    }
                    Console.WriteLine(FlightInfo(_flights[i]));
                }
            }

        }
        else
        {
            for (int i = 0; i < _flights.Count; i++)
            {
                if (_flights[i].Date.Date == DateTime.Today.AddDays(1)) // check if the flight leaves tomorrow
                {
                    _flights[i].Price = (int)(_flights[i].Price * 0.1); // Apply 25% discount
                }
                Console.WriteLine(FlightInfo(_flights[i]));
            }
        }
    }
    public static bool View(int page, string? location, string? date)
    {
        bool feedback = true;
        UpdateFlights();
        List<Flight> flights = new List<Flight>();

        DateTime inputDate = DateTime.MinValue; // Initialize to a default value
        bool hasValidDate = false;

        if (!string.IsNullOrEmpty(date))
        {
            string[] dateFormats = { "d-MM-yyyy", "dd-M-yyyy", "dd-MM-yyyy", "d-M-yyyy" };

            hasValidDate = DateTime.TryParseExact(
                date,
                dateFormats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out inputDate
            );
        }

        foreach (var flight in _flights)
        {
            if (flight.Date.Date == DateTime.Today.AddDays(1)) // check if the flight leaves tomorrow
            {
                flight.Price = (int)(flight.Price * 0.75); // Apply 25% discount
            }

            if (!string.IsNullOrEmpty(location) && location.ToLower() == flight.Destination.ToLower() && !hasValidDate)
            {
                flights.Add(flight);
            }
            else if (hasValidDate && flight.Date.Date == inputDate && string.IsNullOrEmpty(location))
            {
                flights.Add(flight);
            }
            else if (hasValidDate && flight.Date.Date == inputDate && location?.ToLower() == flight.Destination.ToLower())
            {
                flights.Add(flight);
            }
            else if (string.IsNullOrEmpty(date) && string.IsNullOrEmpty(location))
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are no flights with the given data.");
            Console.ResetColor();
            return feedback = false;
        }
        else
        {
            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine(FlightInfo(flights[i]));
            }
        }

        return feedback;
    }


}

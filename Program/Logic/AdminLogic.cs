using System.Collections.Generic;
using System.Text.Json;

public class AdminLogic
{
    private static readonly string AdminUsername = "snus";
    private static readonly string AdminPassword = "snus";

    public static bool AdminLogin(string username, string password)
    {
        return username == AdminUsername && password == AdminPassword;
    }

    public static List<Flight> ViewAllFlights(int page, string location = null, string date = null)
    {
        var flightList = FlightDataRW.ReadJson();
        if (!string.IsNullOrEmpty(location))
        {
            flightList = flightList.Where(f => f.Departure == location || f.Destination == location).ToList();
        }

        if (!string.IsNullOrEmpty(date))
        {
            if (DateTime.TryParse(date, out DateTime parsedDate))
            {
                flightList = flightList.Where(f => f.Date.Date == parsedDate.Date).ToList();
            }
        }

        int pageSize = 10;
        return flightList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public static Flight GetFlightDetails(string flightNumber)
    {
        var flightList = FlightDataRW.ReadJson();
        return flightList.Find(flight => flight.FlightNumber == flightNumber);
    }

    public static void DeleteFlight(Flight flightToDelete)
    {

        var flightList = FlightDataRW.ReadJson();


        var flightToRemove = flightList.FirstOrDefault(f => f.FlightNumber == flightToDelete.FlightNumber);

        if (flightToRemove != null)
        {
            flightList.Remove(flightToRemove);
            FlightDataRW.WriteJson(flightList);
        }
    }


    public static void AddFlight(Flight newFlight)
    {
        var flightList = FlightDataRW.ReadJson();
        flightList.Add(newFlight);
        FlightDataRW.WriteJson(flightList);
    }

    public static Flight CreateNewFlight(string flightNumber, string departure, string destination, DateTime date,
        TimeSpan timeDeparture, TimeSpan timeArrival, TimeSpan duration,
        string status, string country, Aircraft aircraft, int leftSeats, int price)
    {
        return new Flight
        {
            FlightNumber = flightNumber,
            Departure = departure,
            Destination = destination,
            Date = date,
            TimeDeparture = timeDeparture,
            TimeArrival = timeArrival,
            Duration = duration,
            SelectedTimeslots = [],
            Status = status,
            Country = country,
            Aircraft = aircraft,
            Price = price,
        };
    }

    private static readonly string jsonFilePath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBases", "Accounts.json");

    public static List<Account> ViewBookings(string searchText = null)
    {
        try
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var accounts = JsonSerializer.Deserialize<List<Account>>(jsonContent, options);

            if (accounts == null)
            {
                return new List<Account>();
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                return accounts
                    .Where(a =>
                        a.FirstName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        a.LastName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        ($"{a.FirstName} {a.LastName}").Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        ($"{a.LastName} {a.FirstName}").Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        (a.BookedFlights != null && a.BookedFlights.Any(f =>
                            f.FlightNumber.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                            f.Destination.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                            f.Date.ToShortDateString().Contains(searchText, StringComparison.OrdinalIgnoreCase)
                        ))
                    )
                    .ToList();
            }
            else
            {
                return accounts
                    .Where(a => a.BookedFlights != null && a.BookedFlights.Any())
                    .ToList();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            return new List<Account>();
        }
    }
}
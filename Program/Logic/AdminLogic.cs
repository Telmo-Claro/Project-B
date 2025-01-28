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
            return new List<Account>();
        }
    }
    public static void UpdateFlight(Flight updatedFlight)
    {
        var flightList = FlightDataRW.ReadJson();
        
        var existingFlightIndex = flightList.FindIndex(f => f.FlightNumber == updatedFlight.FlightNumber);
    
        if (existingFlightIndex != -1)
        {
            flightList[existingFlightIndex] = updatedFlight;
            FlightDataRW.WriteJson(flightList);
        }
    }
    public static void SaveBookings(Account updatedAccount)
    {
        string jsonContent = File.ReadAllText(jsonFilePath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        var accounts = JsonSerializer.Deserialize<List<Account>>(jsonContent, options);

        if (accounts != null)
        {
            // Find the account by a unique identifier (e.g., combination of first and last name)
            var accountIndex = accounts.FindIndex(a => 
                a.FirstName == updatedAccount.FirstName && 
                a.LastName == updatedAccount.LastName);

            if (accountIndex >= 0)
            {
                // Completely replace the existing account's booked flights
                accounts[accountIndex].BookedFlights = updatedAccount.BookedFlights;

                // Write the updated accounts back to the JSON file
                File.WriteAllText(jsonFilePath, JsonSerializer.Serialize(accounts, options));
            }
        }
    }
    public static void UpdateFlightAndUserBookings(Flight updatedFlight)
{
    // First, update the flight in the flight database
    var flightList = FlightDataRW.ReadJson();
    
    var existingFlightIndex = flightList.FindIndex(f => f.FlightNumber == updatedFlight.FlightNumber);
    
    if (existingFlightIndex != -1)
    {
        flightList[existingFlightIndex] = updatedFlight;
        FlightDataRW.WriteJson(flightList);

        // Now update all user bookings with this flight number
        string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBases", "Accounts.json");
        
        string jsonContent = File.ReadAllText(jsonFilePath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        var accounts = JsonSerializer.Deserialize<List<Account>>(jsonContent, options);

        if (accounts != null)
        {
            bool accountsUpdated = false;

            // Iterate through all accounts
            foreach (var account in accounts)
            {
                // Find bookings with the same flight number
                var matchingBookings = account.BookedFlights
                    .Where(b => b.FlightNumber == updatedFlight.FlightNumber)
                    .ToList();

                // Update the date for matching bookings
                foreach (var booking in matchingBookings)
                {
                    booking.Date = updatedFlight.Date;
                    accountsUpdated = true;
                }
            }

            // If any accounts were updated, save the changes
            if (accountsUpdated)
            {
                File.WriteAllText(jsonFilePath, JsonSerializer.Serialize(accounts, options));
            }
        }
        
    }
    AdminLogic.UpdateFlightAndUserBookings(updatedFlight);
}
    
    
}

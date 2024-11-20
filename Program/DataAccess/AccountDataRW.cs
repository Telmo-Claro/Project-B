using System.Text.Json;

public static class AccountDataRW
{
    private static readonly string
        _filepath = Path.Combine("DataBases", "Accounts.json"); // Standard filepath for accounts

    // Data access - Read from file
    public static List<Account>? ReadFromJson()
    {
        try
        {
            if (File.Exists(_filepath))
            {
                string jsonString = File.ReadAllText(_filepath);
                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    jsonString = "[]";
                }

                return JsonSerializer.Deserialize<List<Account>>(jsonString);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading JSON: {e.Message}");
        }

        return new List<Account>();
    }

    public static void WriteToJson(List<Account> accounts)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(accounts, options);
            File.WriteAllText(_filepath, jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error writing JSON: {e.Message}");
        }
    }

    // This goes to Booking Logic
    public static void Booking(Account? account, string? choice)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");
        try
        {
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);

                bool cancelBooking = false;
                if (accounts is null) return;

                foreach (var x in accounts)
                {
                    if (x.Email == account.Email && x.Password == account.Password
                                                 && x.FirstName == account.FirstName && x.LastName == account.LastName)
                    {
                        switch (choice)
                        {
                            case "1":
                                DisplayBookedFlights.ShowActiveBookings(x);
                                break;
                            case "2":
                                DisplayBookedFlights.ShowPastFlights(x);
                                break;
                            case "3":
                                Menu.CancelBooking(x);
                                cancelBooking = true;
                                break;
                            case "4":
                                break;
                            default:
                                Console.WriteLine("Please enter a valid choice");
                                break;
                        }
                    }
                }

                // double write in Cancelbooking, this fixes this
                if (!cancelBooking)
                {
                    AccountDataRW.WriteToJson(accounts);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Deleting Prior Info: {e.Message}");
        }
    }

    // This goes to Booking Logic
    public static void CancelBooking(Account account, string flightNumber)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");
        try
        {
            if (File.Exists(filepath))
            {
                Flight? cancelledFlight = null;
                string jsonString = File.ReadAllText(filepath);
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);
                if (accounts is null) return;

                foreach (Account x in accounts)
                {
                    if (x.FirstName == account.FirstName && x.LastName == account.LastName
                                                         && x.Email == account.Email
                                                         && x.Password == account.Password)
                    {
                        for (int i = x.BookedFlights.Count - 1; i >= 0; i--)
                        {
                            if (x.BookedFlights[i].FlightNumber == flightNumber)
                            {
                                cancelledFlight = x.BookedFlights[i];
                                x.BookedFlights.RemoveAt(i);
                                x.BookingCodes.RemoveAt(i);
                            }
                        }
                    }
                }

                if (cancelledFlight is not null)
                {
                    Email.SendCancellationEmail(account, cancelledFlight);
                }

                AccountDataRW.WriteToJson(accounts);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Changing Data, Info: {e.Message}");
        }
    }

    // This goes somewhere xD
    public static void ChangeAccount(Account account) // global method for adding booked flight, credit card and booking codes
    {
            var accounts = AccountDataRW.ReadFromJson();
            if (accounts is null) return;
            foreach (Account x in accounts)
            {
                if (x.FirstName == account.FirstName && x.LastName == account.LastName
                                                     && x.Email == account.Email && x.Password == account.Password)
                {
                    x.BookedFlights = account.BookedFlights;
                    x.BookingCodes = account.BookingCodes;
                    x.CreditCardInfo = account.CreditCardInfo;
                }
            }
            AccountDataRW.WriteToJson(accounts);
    }
}
using System.Text.Json;

public static class AccountDataRW
{
    // Data access - Read from file
    public static List<Account>? ReadAccountsFromFile(string filepath)
    {
        try
        {
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
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

    // Data access - Read to file
    public static void WriteJson(Account? account)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");
        var accounts = ReadAccountsFromFile(filepath);

        if (accounts != null)
        {
            var existingAccount = accounts.FirstOrDefault(x => x.Id == account.Id);
            if (existingAccount != null)
            {
                accounts.Remove(existingAccount);
                accounts.Add(account);
            }
            else
            {
                accounts.Add(account);
            }
        }
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJsonString = JsonSerializer.Serialize(accounts, options);
            File.WriteAllText(filepath, updatedJsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error writing JSON: {e.Message}");
        }
    }

    // This goes to Logic
    public static Account? LoggingIn(string email, string password)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");

        try
        {
            // Check if the file exists
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                // Try to deserialize the content to a List of Accounts
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);

                if (accounts is null) return null;

                foreach (var account in accounts)
                {
                    if (account.Email == email && account.Password == password)
                    {
                        return account;
                    }
                }
                Console.WriteLine("No matches with the given credentials");
                Console.ReadKey();
                Menu.LoginMenu();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading JSON {e.Message}");
            Console.ReadKey();
        }
        return null;
    }

    // Merge with writeJson
    public static void ChangeJson(string jsonstring)
    {
        var filepath = Path.Combine("DataBases", "Accounts.json");
        try
        {
            if (File.Exists(filepath))
            {
                File.WriteAllText(filepath, jsonstring);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error changing JSON: {e.Message}");
        }
    }

    // This goes to Logic
    public static void DeleteAccount(string? email)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");

        try
        {
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);
                if (accounts is null) return;

                var accountToRemove = accounts.FirstOrDefault(x => x.Email == email);
                if (accountToRemove != null)
                {
                    accounts.Remove(accountToRemove);
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string updatedJsonString = JsonSerializer.Serialize(accounts, options);

                    ChangeJson(updatedJsonString);
                    Console.Clear();
                    Console.WriteLine("Account deleted succesfully");

                    Console.ReadKey();
                    Menu.WelcomingMenu();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Deleting Json: {e.Message}");
            Console.ReadKey();
        }
    }

    // This goes to Logic
    public static void ChangeData(Account? account, int choice)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");
        try
        {
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);
                if (accounts is null) return;

                foreach (var x in accounts)
                {
                    if (x.Email == account.Email && x.Password == account.Password
                        && x.FirstName == account.FirstName && x.LastName == account.LastName)
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter new first name: ");
                                x.FirstName = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter new last name: ");
                                x.LastName = Console.ReadLine();
                                Console.WriteLine("Name changed successfully!");
                                break;
                            case 2:
                                Console.Write("Enter new email: ");
                                x.Email = Console.ReadLine();
                                Console.WriteLine("Email changed successfully!");
                                break;
                            case 3:
                                Console.Write("Enter new phone number: ");
                                x.PhoneNumber = Console.ReadLine();
                                Console.WriteLine("Phone number changed successfully");
                                break;
                            case 4:
                                Console.Write("Enter new password: ");
                                x.Password = Console.ReadLine();
                                Console.WriteLine("Password changed successfully!");
                                break;
                            case 5:
                                Menu.DisplayCreditCardInfo(x);
                                Console.Write("Do you wish to change your information? y/n: ");
                                bool boolChoice = Console.ReadKey().KeyChar.ToString().ToUpper() == "Y" ? true : false;
                                if (boolChoice)
                                {
                                    x.CreditCardInfo = ClassFactory.CreateCreditCard();
                                    Console.WriteLine("Payment method changed successfully!");
                                }
                                break;
                            case 6:
                                break;
                            default:
                                Console.WriteLine("Please enter a valid choice");
                                break;
                        }
                    }
                }
                var options = new JsonSerializerOptions { WriteIndented = true };
                string updatedJsonString = JsonSerializer.Serialize(accounts, options);

                File.WriteAllText(filepath, updatedJsonString);            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Deleting Prior Info: {e.Message}");
        }
    }

    // This goes to Logic
    public static void Booking(Account? account, string? choice)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");
        try
        {
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);
                if (accounts is null) return;

                foreach (var x in accounts)
                {
                    if (x.Email == account.Email && x.Password == account.Password
                        && x.FirstName == account.FirstName && x.LastName == account.LastName)
                    {
                        switch (choice)
                        {
                            case "1":
                                Menu.ShowActiveBookings(x);
                                break;
                            case "2":
                                Menu.ShowPastFlights(x);
                                break;
                            case "3":

                                break;
                            case "4":
                                break;
                            default:
                                Console.WriteLine("Please enter a valid choice");
                                break;
                        }
                    }
                }
                var options = new JsonSerializerOptions { WriteIndented = true };
                string updatedJsonString = JsonSerializer.Serialize(accounts, options);

                ChangeJson(updatedJsonString);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Deleting Prior Info: {e.Message}");
        }
    }

    // This goes to Logic
    public static void AddBooking(Account account)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");
        try
        {
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);
                if (accounts is null) return;

                foreach (Account x in accounts)
                {
                    if (x.FirstName == account.FirstName && x.LastName == account.LastName
                        && x.Email == account.Email && x.Password == account.Password)
                    {
                        x.BookedFlights = account.BookedFlights;
                    }
                }

                var options = new JsonSerializerOptions { WriteIndented = true };
                string updatedJsonString = JsonSerializer.Serialize(accounts, options);

                ChangeJson(updatedJsonString);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Changing Booked Flights Info: {e.Message}");
        }
    }

    // This goes to logic
    public static void AddCreditcard(Account account)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");
        try
        {
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);
                if (accounts is null) return;

                foreach (Account x in accounts)
                {
                    if (x.FirstName == account.FirstName && x.LastName == account.LastName
                        && x.Email == account.Email && x.Password == account.Password)
                    {
                        x.CreditCardInfo = account.CreditCardInfo;
                    }
                }

                var options = new JsonSerializerOptions { WriteIndented = true };
                string updatedJsonString = JsonSerializer.Serialize(accounts, options);

                ChangeJson(updatedJsonString);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Changing Booked Flights Info: {e.Message}");
        }
    }
}
using System.Text.Json;

public static class AccountDataRW
{
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
    public static void WriteJson(Account? account)
    {
        string filepath = Path.Combine("DataBases", "Accounts.json");
        List<Account?> accounts = new List<Account?>();

        try
        {
            // Check if the file exists
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);

                // If the file is empty, treat it as an empty array
                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    jsonString = "[]";
                }

                // Try to deserialize the content to a List of Accounts
                accounts = JsonSerializer.Deserialize<List<Account>>(jsonString)!;
            }

            // Add the new account to the list
            accounts.Add(account);

            // Serialize the updated list back to the file
            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJsonString = JsonSerializer.Serialize(accounts, options);

            File.WriteAllText(filepath, updatedJsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error writing JSON: {e.Message}");
        }
    }


    private static void ChangeJson(string jsonstring)
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

                foreach (var account in accounts)
                {
                    if (account.Email == email)
                    {
                        accounts.Remove(account);
                        break;
                    }
                }
                var options = new JsonSerializerOptions { WriteIndented = true };
                string updatedJsonString = JsonSerializer.Serialize(accounts, options);

                ChangeJson(updatedJsonString);
                Console.Clear();
                Console.WriteLine("Account deleted succesfully");

                Console.ReadKey();
                Menu.WelcomingMenu();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Deleting Json: {e.Message}");
            Console.ReadKey();
        }
    }
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
                                    x.CreditCardInfo = InputCreditCardInfo.CreateCreditCard();
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

                ChangeJson(updatedJsonString);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Deleting Prior Info: {e.Message}");
        }
    }

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

    public static void ChangeAccount(Account account) // global method for adding booked flight, credit card and booking codes
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
                        x.BookingCodes = account.BookingCodes;
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
            Console.WriteLine($"Error Changing Data, Info: {e.Message}");
        }
    }
}
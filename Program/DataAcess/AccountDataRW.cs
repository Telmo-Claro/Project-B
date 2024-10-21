using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public static class AccountDataRW
{
    public static Account LoggingIn(string email, string password)
    {
        string filepath = "DataBases\\Accounts.json";

        try
        {
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);

                foreach (var account in accounts)
                {
                    if (account.Email == email && account.Password == password)
                    {
                        Account User = new Account(account.FirstName, account.LastName, account.Email, account.PhoneNumber, account.Password);
                        return User;
                    }
                }
                Console.WriteLine("No matches with the given credentials");
                Console.ReadKey();
                Menu.loginMenu();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading JSON {e.Message}");
            Console.ReadKey();
        }
        return null;
    }
    public static void WriteJson(Account account)
    {
        string filepath = "DataBases\\Accounts.json";
        List<Account> accounts = new List<Account>();

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

    public static void ChangeJson(string jsonstring)
    {
        string filepath = "DataBases\\Accounts.json";

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
    public static void DeleteAccount(string email)
    {
        string filepath = "DataBases\\Accounts.json";

        try
        {
            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                var accounts = JsonSerializer.Deserialize<List<Account>>(jsonString);

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
                Menu.welcomingMenu();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Deleting Json: {e.Message}");
            Console.ReadKey();
        }
    }
}
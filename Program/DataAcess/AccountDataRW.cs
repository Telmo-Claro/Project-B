using System.Text.Json;

public static class AccountDataRW
{
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
}
using System.Text.Json;

public static class AccountDataRW
{
    private static readonly string
        _filepath = Path.Combine("DataBases", "Accounts.json"); // Standard filepath for accounts

    // Data access - Read from file
    public static List<Account> ReadFromJson()
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
}
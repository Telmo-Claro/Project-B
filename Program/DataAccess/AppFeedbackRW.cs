using System.Text.Json;

public static class AppFeedbackRW
{
    public static List<Feedback> ReadJson()
    {
        try
        {
            string jsonString = File.ReadAllText(Path.Combine("DataBases", "Reviews.json"));
            return JsonSerializer.Deserialize<List<Feedback>>(jsonString)!;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading JSON: {e.Message}");
            return new List<Feedback>();
        }
    }

    public static void WriteJson(List<Feedback> reviews)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(reviews, options);
            File.WriteAllText(Path.Combine("DataBases", "Reviews.json"), jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error writing JSON: {e.Message}");
        }
    }
}
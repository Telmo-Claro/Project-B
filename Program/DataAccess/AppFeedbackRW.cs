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
            ErrorMessagePrinter.PrintError(e);
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
            ErrorMessagePrinter.PrintError(e);
        }
    }
}
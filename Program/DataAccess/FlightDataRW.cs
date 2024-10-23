using System.Text.Json;
public static class FlightDataRW
{
    public static List<Flight> ReadJson()
    {
        try
        {
            string jsonString = File.ReadAllText(Path.Combine("DataBases", "Flights.json"));
            return JsonSerializer.Deserialize<List<Flight>>(jsonString)!;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading JSON: {e.Message}");
            return new List<Flight>();
        }
    }

    public static void WriteJson(List<Flight> flights)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(flights, options);
            File.WriteAllText(Path.Combine("DataBases", "Flights.json"), jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error writing JSON: {e.Message}");
        }
    }

    
    
    
    
    
}

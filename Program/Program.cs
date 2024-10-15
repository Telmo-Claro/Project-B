using System.Text.Json;
public class Program
{
    public static void Main()
    {
        //Menu.welcomingMenu();
        string jsonString = File.ReadAllText("DataBases\\Flights.json");
        List<Flight> flightsData = JsonSerializer.Deserialize<List<Flight>>(jsonString)!;

        foreach (Flight flight in flightsData)
        {
            Console.WriteLine(flight);
        }    
    }
}
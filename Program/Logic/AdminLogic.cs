public class AdminLogic
{
    private static readonly string AdminUsername = "snus";
    private static readonly string AdminPassword = "snus";

    public static bool AdminLogin(string username, string password)
    { return username == AdminUsername && password == AdminPassword; }
    
    public static List<Flight> ViewAllFlights(int page, string location = null, string date = null)
    {
        var flightList = FlightDataRW.ReadJson(); 
        if (!string.IsNullOrEmpty(location))
        {
            flightList = flightList.Where(f => f.Departure == location || f.Destination == location).ToList();
        }
        if (!string.IsNullOrEmpty(date))
        {
            if (DateTime.TryParse(date, out DateTime parsedDate))
            {
                flightList = flightList.Where(f => f.Date.Date == parsedDate.Date).ToList();
            }
        }
        int pageSize = 10; 
        return flightList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public static Flight GetFlightDetails(string flightNumber)
    {
    var flightList = FlightDataRW.ReadJson();
    return flightList.Find(flight => flight.FlightNumber == flightNumber);
    }
    
     public static void DeleteFlight(Flight flightToDelete)
     {
         
         var flightList = FlightDataRW.ReadJson();
    
         
         var flightToRemove = flightList.FirstOrDefault(f => f.FlightNumber == flightToDelete.FlightNumber);
    
         if (flightToRemove != null)
         {
             flightList.Remove(flightToRemove);
             FlightDataRW.WriteJson(flightList);
         }
     }
     
     
    public static void AddFlight(Flight newFlight) 
    {
    var flightList = FlightDataRW.ReadJson();
    flightList.Add(newFlight);
    FlightDataRW.WriteJson(flightList);
    }
    
    public static Flight CreateNewFlight(string flightNumber, string departure, string destination, DateTime date,
        TimeSpan timeDeparture, TimeSpan timeArrival, TimeSpan duration, 
        string status, string country, Aircraft aircraft, int leftSeats, int price)
    {
        return new Flight
        {
            FlightNumber = flightNumber,
            Departure = departure,
            Destination = destination,
            Date = date,
            TimeDeparture = timeDeparture,
            TimeArrival = timeArrival,
            Duration = duration,
            Status = status,
            Country = country,
            Aircraft = aircraft,
            Price = price
        };
    }
}
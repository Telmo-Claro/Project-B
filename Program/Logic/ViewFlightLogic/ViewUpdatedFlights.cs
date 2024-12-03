using System.ComponentModel;

public static class ViewUpdatedFlights
{
    public static List<Flight> UpdateFlights()
    {
        var now = DateTime.Now;
        List<Flight> _flights = FlightDataRW.ReadJson();
        // Filter flights that have a date less than the current time.
        return _flights.Where(flight => flight != null && flight.Date > now).ToList();
    }
}
public static class ViewUpdatedFlights
{
    private static List<Flight> _flights = FlightDataRW.ReadJson();

    public static List<Flight> UpdateFlights()
    {
        var now = DateTime.Now;
        
        // Filter flights that have a date less than the current time.
        return _flights.Where(flight => flight != null && flight.Date > now).ToList();
    }
}
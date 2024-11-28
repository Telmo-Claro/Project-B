public static class ViewUpdatedFlights
{
    public static List<Flight> _flights = FlightDataRW.ReadJson();

    public static List<Flight> UpdateFlights()
    {
        var now = DateTime.Now;
        
        //var flights = FlightDataRW.ReadJson();
        
        // Filter flights that have a date less than the current time.
        //return _flights.Where(flight => flight != null && flight.Date > now).ToList();
        return _flights.Where(flight =>
                flight != null &&
                (flight.Date.Date > now.Date ||  
                 (flight.Date.Date == now.Date && flight.TimeDeparture >= now.TimeOfDay)) 
        ).ToList();
    }
    public static void RefreshCache()
    {
        _flights = FlightDataRW.ReadJson();
    }
}
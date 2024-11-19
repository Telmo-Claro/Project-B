public static class BookingLogic
{
    public static List<Seat> GetSeats(Flight flight)
    {
        switch (flight.Aircraft.Name)
        {
            case "Airbus 330":
                {
                    return OverviewAirbus330.Display330(flight);
                }
            case "Boeing 737":
                {
                    return OverviewBoeing737.Display737(flight);
                }
            case "Boeing 787":
                {
                    return OverviewBoeing787.Display787(flight);
                }
            default:
                {
                    return null;
                }
        }
    }
}
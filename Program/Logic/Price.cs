public static class Price
{
    public static int GetTotalPrice(Flight flight, List<Seat> seat, bool flightExperience)
    {
        int trentax = 50;
        int priceSeats = 0;
        int flightExperiencePrice = 50;
        foreach (Seat zetel in seat)
        {
            priceSeats += zetel.GetPrice();
        }
        if (flightExperience is true)
        {
            return priceSeats + flight.Price + trentax + flightExperiencePrice;
        }
        return priceSeats + flight.Price + trentax;
    }
    public static int GetSeatPrices(List<Seat> seat)
    {
        int priceSeats = 0;
        foreach (Seat zetel in seat)
        {
            priceSeats += zetel.GetPrice();
        }
        return priceSeats;
    }
    public static int FlightExperiencePrice(bool flightExperience)
    {
        if (flightExperience is true)
        {
            return 50;
        }
        else
        {
            return 0;
        }
    }
}
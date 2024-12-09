public static class Price
{
    public static int GetTotalPrice(Flight flight, List<Seat> seat, bool flightExperience, string? catering)
    {
        int totalPrice = 0;
        int trentax = 50;
        int flightExperiencePrice = 50;
        foreach (Seat zetel in seat)
        {
            totalPrice += zetel.GetPrice();
        }
        if (flightExperience is true)
        {
            totalPrice += flightExperiencePrice;
        }
        if (catering is not null)
        {
            totalPrice += CateringPrice(catering);
        }
        return totalPrice + flight.Price + trentax;
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
    public static int CateringPrice(string catering)
    {
        if (catering == "Basic")
        {
            return 8;
        }
        else if (catering == "Standard")
        {
            return 20;
        }
        else if (catering == "Premium")
        {
            return 60;

        }
        return 0;
    }
}
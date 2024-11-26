public static class Price
{
    public static int GetTotalPrice(Flight flight, List<Seat> seat)
    {
        int trentax = 50;
        int priceSeats = 0;
        foreach (Seat zetel in seat)
        {
            priceSeats += zetel.GetPrice();
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
}
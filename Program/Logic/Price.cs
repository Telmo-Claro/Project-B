public static class Price
{
    public static int GetPrice(Flight flight, List<Seat> seat)
    {
        int trentax = 50;
        int priceSeats = 0;
        foreach (Seat zetel in seat)
        {
            priceSeats += zetel.GetPrice();
        }
        return priceSeats + flight.Price + trentax;
    }
}
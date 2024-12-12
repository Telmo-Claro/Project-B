
static class MakeBookingLogic
{
    public static Booking MakeBooking(Flight flight, string bookingcode, List<Seat> seats, TimeSpan? specialExperience, int totalprice, string catering)
    {
        Booking booking = new Booking();
        booking.BookingCode = bookingcode;
        booking.FlightNumber = flight.FlightNumber;
        booking.Departure = flight.Departure;
        booking.Destination = flight.Destination;
        booking.Date = flight.Date;
        booking.TimeDeparture = flight.TimeDeparture;
        booking.TimeArrival = flight.TimeArrival;
        booking.Seats = seats;
        booking.SpecialExperience = specialExperience;
        booking.Catering = catering;
        booking.Price = totalprice;
        return booking;
    }
    
}


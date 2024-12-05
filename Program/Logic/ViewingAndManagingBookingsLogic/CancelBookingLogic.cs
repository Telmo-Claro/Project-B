using System.Runtime.InteropServices.JavaScript;

public static class CancelBookingLogic
{
    public static bool ValidFlight(Account account, string bookingnumber)
    {
        foreach (var flight in account.BookedFlights)
        {
            if (flight.BookingCode == bookingnumber)
            {
                return true;
            }
        }
        return false;
    }

    public static bool CanGetRefund(Account account, string bookingnumber)
    {
        DateTime flightDate = default;
        foreach (var flight in account.BookedFlights)
        {
            if (flight.BookingCode == bookingnumber)
            {
                flightDate = Convert.ToDateTime(flight.Date);
            }
        }
        var now = DateTime.Now;
        return (flightDate - now).TotalHours >= 24;
    }
    
    public static void CancelBooking(Account account, string bookingnumber)
    {
        Booking cancelledFlight = null;
        var flights = FlightDataRW.ReadJson();
        var accounts = AccountDataRW.ReadFromJson();
        if (accounts is null) return;
        foreach (Account x in accounts)
        {
            if (x.FirstName == account.FirstName && x.LastName == account.LastName
                                                 && x.Email == account.Email
                                                 && x.Password == account.Password)
            {
                for (int i = x.BookedFlights.Count - 1; i >= 0; i--)
                {
                    if (x.BookedFlights[i].BookingCode == bookingnumber)
                    {
                        cancelledFlight = x.BookedFlights[i];
                        foreach (var flight in flights)
                        {
                            if (flight.FlightNumber == x.BookedFlights[i].FlightNumber)
                            {
                                flight.Aircraft.BookedSeats = flight.Aircraft.BookedSeats
                                    .Where(seat => !x.BookedFlights[i].Seats.Any(s => s.SeatId == seat.SeatId))
                                    .ToList();
                                break;
                            }
                        }
                        x.BookedFlights.RemoveAt(i);
                    }
                }
            }
        }
        AccountDataRW.WriteToJson(accounts);
        FlightDataRW.WriteJson(flights);
        if (cancelledFlight is not null)
        {
            Email.SendCancellationEmail(account, cancelledFlight);
        }
        MainBookingPresentation.DisplayMenu(account);
    }
}
public static class CancelBookingLogic
{
    public static void CancelBooking(Account account, string flightNumber)
    {
        Flight cancelledFlight = null;
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
                    if (x.BookedFlights[i].FlightNumber == flightNumber)
                    {
                        cancelledFlight = x.BookedFlights[i];
                        x.BookedFlights.RemoveAt(i);
                        x.BookingCodes.RemoveAt(i);
                    }
                }
            }
        }
        if (cancelledFlight is not null)
        {
            Email.SendCancellationEmail(account, cancelledFlight);
        }
        AccountDataRW.WriteToJson(accounts);
        MainBookingPresentation.DisplayMenu(account);
    }
}
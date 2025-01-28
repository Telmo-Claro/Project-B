public class ManageBookingsLogic
{
    public static void ManageBooking(Account account, ConsoleKey choice)
    {
        var accounts = AccountDataRW.ReadFromJson();
        bool cancelBooking = false;
        if (accounts is null) return;
        foreach (var x in accounts)
        {
            if (x.Email == account.Email && x.Password == account.Password
                                         && x.FirstName == account.FirstName && x.LastName == account.LastName)
            {
                switch (choice)
                {
                    case ConsoleKey.D1:
                        DisplayBookedFlights.ShowActiveBookings(x);
                        break;
                    case ConsoleKey.D2:
                        DisplayBookedFlights.ShowPastFlights(x);
                        break;
                    case ConsoleKey.D3:
                        CancelBookingPresentation.CancelBooking(x);
                        cancelBooking = true;
                        break;
                    case ConsoleKey.Tab or ConsoleKey.Escape:
                        LoggedInPresentation.DisplayMenu(account);
                        break;
                    default:
                        DisplayAccountInfo.WrongChoice();
                        break;
                }
            }
        }
        // double write in Cancelbooking, this fixes this
        if (!cancelBooking)
        {
            AccountDataRW.WriteToJson(accounts);
        }
    }
}
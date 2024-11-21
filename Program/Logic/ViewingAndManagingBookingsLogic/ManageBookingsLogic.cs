public class ManageBookingsLogic
{
    public static void ManageBooking(Account account, string choice)
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
                    case "1":
                        DisplayBookedFlights.ShowActiveBookings(x);
                        break;
                    case "2":
                        DisplayBookedFlights.ShowPastFlights(x);
                        break;
                    case "3":
                        CancelBookingPresentation.CancelBooking(x);
                        cancelBooking = true;
                        break;
                    case "\t":
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
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
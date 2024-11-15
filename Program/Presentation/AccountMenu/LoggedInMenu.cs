public static class LoggedInMenu
{
    public static void LoggedIn(Account account)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine($"TRENLINES - Welcome {account.FirstName}!");
            Console.WriteLine("----------------------------");

            Console.WriteLine("What do you wish to do:");
            Console.WriteLine("(1) View and book flights");
            Console.WriteLine("(2) View and manage bookings");
            Console.WriteLine("(3) Manage account");
            Console.WriteLine("(4) Delete account");
            Console.WriteLine("(5) Exit");

            string input = Console.ReadKey().KeyChar.ToString();

            switch (input)
            {
                case "1":
                    Menu.ViewFlightMenu(account);
                    break;
                case "2":
                    var bookingChoice = Menu.BookingMenu(account);
                    AccountDataRW.Booking(account, bookingChoice);
                    //ViewBookedFlights.PrintBookedFlight(account.BookedFlights);
                    break;
                case "3":
                    Menu.ManageAccount(account);
                    break;
                case "4":
                    DeleteAccountMenu.DeleteAccount(account);
                    break;
                case "5":
                    WelcomingMenu.Menu();
                    break;
                case "6":
                    LoggedIn(account);
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
public static class LoggedInPresentation
{
    public static void DisplayMenu(Account account)
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
            Console.WriteLine("(ESC) Exit");
            Console.Write("> ");
            string input = Console.ReadKey().KeyChar.ToString();
            if (input == "\t")
            {
                WelcomingMenu.Menu();
            }
            switch (input)
            {
                case "1":
                    ViewFlightMenu.DisplayMenu(account);
                    break;
                case "2":
                    var bookingChoice = MainBookingPresentation.DisplayMain(account);
                    ManageBookingsLogic.ManageBooking(account, bookingChoice);
                    break;
                case "3":
                    ChangeAccountDataPresentation.DisplayMenu(account);
                    break;
                case "4":
                    DeleteAccountPresentation.DisplayMenu(account);
                    break;
                case "5":
                    WelcomingMenu.Menu();
                    break;
                case "ESC":
                    DisplayMenu(account);
                    break;
                case "TAB":
                    DisplayMenu(account);
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
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
            Console.WriteLine("(5) About Airport");
            Console.WriteLine("(6) Write a review");
            Console.WriteLine("(ESC) Log out");
            Console.Write("> ");
            var input = Console.ReadKey().Key;
            if (input is ConsoleKey.Escape or ConsoleKey.Tab)
            {
                WelcomingMenu.Menu();
            }
            switch (input)
            {
                case ConsoleKey.D1:
                    ViewFlightMenu.DisplayMenu(account);
                    break;
                case ConsoleKey.D2:
                    MainBookingPresentation.DisplayMenu(account);
                    break;
                case ConsoleKey.D3:
                    ChangeAccountDataPresentation.DisplayMenu(account);
                    break;
                case ConsoleKey.D4:
                    DeleteAccountPresentation.DisplayMenu(account);
                    break;
                case ConsoleKey.D5:
                    DisplayAirportInfo.DisplayMain(account);
                    break;
                case ConsoleKey.D6:
                    WriteReviewMenu.DisplayMenu(account);
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
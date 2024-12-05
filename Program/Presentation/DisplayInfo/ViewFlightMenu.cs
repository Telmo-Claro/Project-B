public static class ViewFlightMenu
{
    public static void DisplayMenu(Account account)
    {
        int page = 1;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("TRENLINES - BOOKING A FLIGHT");
            Console.WriteLine("----------------------------");
            Console.WriteLine("           Flights          ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("FlightNumber|Departure|Destination|   Date   |TimeDeparture|TimeArrival|Duration|    Country    |   Aircraft  | Price | Status");
            ViewFlights.View(page);
            Console.WriteLine("--------------");
            Console.WriteLine($"Page: {page}");
            Console.WriteLine("--------------");
            Console.WriteLine("Press [S] to search");
            Console.WriteLine("To book a flight, please press [B]");
            Console.WriteLine("Or press 'ESC' to return");
            Console.Write("> ");
            ConsoleKey key = Console.ReadKey().Key;
            page = PageScroller.NextPage(key, page);
            if (key == ConsoleKey.Escape || key == ConsoleKey.Tab) { LoggedInPresentation.DisplayMenu(account); }
            if (key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("Search (leave empty for all):");
                Console.Write("Location: ");
                string? location = Console.ReadLine();
                Console.Write("Date (DD/MM/YYYY): ");
                string? date = Console.ReadLine();
                ViewSearchFlightsMenu.DisplayMenu(location, date, account);
                break;
            }
            if (key == ConsoleKey.B)
            {
                BookFlightMenu.BookingMenu(account);
            }
        }
    }
}
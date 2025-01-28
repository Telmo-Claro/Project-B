public class ViewSearchFlightsMenu
{
    public static void DisplayMenu(string locationSearch, string dateSearch, Account account)
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
            Console.WriteLine("FlightNumber|Departure |Destination |   Date   |TimeDeparture|TimeArrival  |Duration |    Country    |   Aircraft   | Price   | Status");
            bool feedback = ViewFlights.View(page, locationSearch, dateSearch);
            Console.WriteLine("--------------");
            Console.WriteLine($"Page: {page}");
            Console.WriteLine("--------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (feedback)
                Console.WriteLine("Use the \u2190 and \u2192 arrows on your keyboard to navigate through the list");
            Console.ResetColor();
            Console.WriteLine("Press 'Enter' to view all the flights again.");
            Console.WriteLine("Press S search");
            if (feedback)
                Console.WriteLine("To book a flight, check the flightnumber and press B");
            ConsoleKey key = Console.ReadKey().Key;
            page = PageScroller.NextPage(key, page);
            if (key == ConsoleKey.Enter) ViewFlightMenu.DisplayMenu(account);
            if (key == ConsoleKey.Escape || key == ConsoleKey.Tab) { break; }
            if (key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("Search (leave empty for all):");
                Console.Write("Location: ");
                string? location = Console.ReadLine();
                Console.Write("Date (DD/MM/YYYY): ");
                string? date = Console.ReadLine();
                DisplayMenu(location, date, account);
                break;
            }
            if (feedback)
                if (key == ConsoleKey.B)
                {
                    BookFlightMenu.BookingMenu(account);
                }
        }
    }
}
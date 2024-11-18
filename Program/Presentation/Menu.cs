public static class Menu
{
    public static string ManageFlightMenu(Account? account)
    {
        Console.Clear();
        Console.WriteLine("---------------- TRENLINES -----------------");
        Console.WriteLine($"Hello {account.FirstName} {account.LastName}!");
        Console.WriteLine($"(1) View booking details of active bookings");
        Console.WriteLine($"(2) View booking details of past flights");
        Console.WriteLine($"(3) Cancel booking");
        Console.WriteLine($"(4) Go back");
        Console.WriteLine("---------------- TRENLINES -----------------\n");
        Console.Write("> ");
        return Console.ReadLine();
    }

    public static void CancelBooking(Account account)
    {
        Console.WriteLine($"----------------------");
        Console.WriteLine($"Current booked flights");
        Console.WriteLine($"----------------------");
        foreach (var flight in account.BookedFlights)
        {
            int index = account.BookedFlights.IndexOf(flight);
            if (flight.Status == "Planned")
            {
                Console.WriteLine($"Booking code {account.BookingCodes[index]}");
                Console.WriteLine($"Flight number: {flight.FlightNumber}");
                Console.WriteLine($"Flight Departure: {flight.Departure}");
                Console.WriteLine($"Flight Destination: {flight.Destination}");
                Console.WriteLine($"Flight Date: {flight.Date}");
                Console.WriteLine($"Flight TimeDeparture: {flight.TimeDeparture}");
                Console.WriteLine($"Flight TimeArrival: {flight.TimeArrival}");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
            }
        }

        bool choicemade = false;
        string choice = string.Empty;
        while (!choicemade)
        {
            Console.WriteLine("Do you want to cancel booking? [Y/N]");
            string key = Console.ReadKey().Key.ToString();
            switch (key.ToLower())
            {
                case "y":
                    choice = "y";
                    choicemade = true;
                    break;
                case "n":
                    choice = "n";
                    choicemade = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
            Console.WriteLine();
        }

        switch (choice.ToLower())
        {
            case "y":
                Console.Write("Enter the flight number you want to cancel: ");
                string? flightNumber = Console.ReadLine();
                AccountDataRW.CancelBooking(account, flightNumber);
                Console.WriteLine("Booking cancelled successfully!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            case "n":
                ManageFlightMenu(account);
                break;
        }

    }

    public static void DisplayFlightInfo(Flight flight)
    {
        Console.Clear();
        Console.WriteLine("---------------- TRENLINES -----------------");
        Console.WriteLine($"Flight number: {flight.FlightNumber}");
        Console.WriteLine($"Departure: {flight.Departure}");
        Console.WriteLine($"Destination: {flight.Destination}");
        Console.WriteLine($"Date: {flight.Date}");
        Console.WriteLine($"Time Departure: {flight.TimeDeparture}");
        Console.WriteLine($"Time Arrival: {flight.TimeArrival}");
        Console.WriteLine("--------------------------------------------");
    }

    public static void ViewFlightMenu(Account account)
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
            Console.WriteLine("Press S search");
            Console.WriteLine("To book a flight, press B");
            ConsoleKey key = Console.ReadKey().Key;
            page = PageScroller.NextPage(key, page);
            if (key == ConsoleKey.Escape || key == ConsoleKey.Tab) { break; }
            if (key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("Search (leave empty for all):");
                Console.Write("Location: ");
                string? location = Console.ReadLine();
                Console.Write("Date (DD/MM/YYYY): ");
                string? date = Console.ReadLine();
                ViewSearchFlightsMenu(location, date, account);
                break;
            }
            if (key == ConsoleKey.B)
            {
                BookFlightMenu.BookingMenu(account);
            }
        }
    }

    public static void ViewSearchFlightsMenu(string locationSearch, string dateSearch, Account account)
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
            Console.WriteLine("FlightNumber|Departure|Destination|   Date   |TimeDeparture|TimeArrival|Duration|    Country    |   Aircraft  | Status");
            ViewFlights.View(page, locationSearch, dateSearch);
            Console.WriteLine("--------------");
            Console.WriteLine($"Page: {page}");
            Console.WriteLine("--------------");
            Console.WriteLine("Press S search");
            Console.WriteLine("To book a flight, check the flightnumber and press B");
            ConsoleKey key = Console.ReadKey().Key;
            page = PageScroller.NextPage(key, page);
            if (key == ConsoleKey.Escape || key == ConsoleKey.Tab) { break; }
            if (key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("Search (leave empty for all):");
                Console.Write("Location: ");
                string? location = Console.ReadLine();
                Console.Write("Date (DD/MM/YYYY): ");
                string? date = Console.ReadLine();
                ViewSearchFlightsMenu(location, date, account);
                break;
            }
            if (key == ConsoleKey.B)
            {
                BookFlightMenu.BookingMenu(account);
            }
        }
    }
}
public static class Menu
{
    public static void ShowActiveBookings(Account account)
    {
        Console.Clear();
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
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

    }

    public static void ShowPastFlights(Account account)
    {
        Console.Clear();
        Console.WriteLine($"----------------------");
        Console.WriteLine($"Past flights");
        Console.WriteLine($"----------------------");
        foreach (var flight in account.BookedFlights)
        {
            int index = account.BookedFlights.IndexOf(flight);
            if (flight.Status == "Departed")
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
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static string BookingMenu(Account? account)
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
                string flightNumber = Console.ReadLine();
                AccountDataRW.CancelBooking(account, flightNumber);
                Console.WriteLine("Booking cancelled successfully!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            case "n":
                BookingMenu(account);
                break;
        }

    }

    public static void DisplayAccountInfo(Account account)
    {
        Console.Clear();
        Console.WriteLine("---------------- TRENLINES -----------------");
        Console.WriteLine($"Account name: {account.FirstName} {account.LastName}");
        Console.WriteLine($"Account email: {account.Email}");
        Console.WriteLine($"Account phone number: {account.PhoneNumber}");
        Console.WriteLine("--------------------------------------------");
    }


    public static string DisplayCreditCardInfo(Account account)
    {
        return "---------------- TRENLINES -----------------\n" +
            $"CreditCard Name: {account.CreditCardInfo.FirstName} {account.CreditCardInfo.LastName}\n" +
            $"CreditCard Number: {account.CreditCardInfo.Number}\n" +
            $"CreditCard Expiration Date: {account.CreditCardInfo.ExpirationDate}\n" +
            $"CreditCard CVC: {account.CreditCardInfo.CvcCode}\n" +
            "--------------------------------------------\n";
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
                BookFlightMenu(account);
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
                BookFlightMenu(account);
            }
        }
    }
    private static readonly List<Flight> _flights = FlightDataRW.ReadJson();
    public static void BookFlightMenu(Account account)
    {
        Console.Clear();
        Console.WriteLine("What is the flightnumber from the flight you would like to book?");
        string? givenFlightNumber = Console.ReadLine();

        foreach (Flight flight in _flights)
        {
            if (flight.FlightNumber == givenFlightNumber)
            {
                Console.Clear();
                Console.WriteLine(@$"Is this the flight you would like to book?
Flightnumber: {flight.FlightNumber}
Departure: {flight.Departure}
Destination: {flight.Destination}
Date: {flight.Date}
Departure time: {flight.TimeDeparture}
Arrival time: {flight.TimeArrival}
Duration: {flight.Duration}");

                Console.WriteLine("Correct flight? (Y/N)");
                ConsoleKey key = Console.ReadKey().Key;
                while (true)
                {
                    if (key == ConsoleKey.Y)
                    {
                        BookFlight(account, flight);
                        break;
                    }

                    else if (key == ConsoleKey.N)
                    {
                        Console.WriteLine(@"Make sure you enter the correct flightnumber.
Press any key to continue.");
                        Console.ReadKey();
                        BookFlightMenu(account);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                        break;
                    }
                }
            }
        }


    }

    public static void BookFlight(Account account, Flight flight)
    {

        List<Seat> seats = General_Seat_Logic.GetSeats(flight);

        if (seats.Count == 0) { return; }
        Console.WriteLine("if you are interested in the special experience press (1), you will be contacted about further details.");
        Console.ReadKey();
        Console.Clear();

        int totalprice = Price.GetPrice(flight, seats);
        Console.WriteLine($@"The costs will be €{totalprice}
Press any key to continue.");
        Console.ReadKey();

        while (true)
        {
            ConsoleKey key = Console.ReadKey().Key;
            Console.Clear();
            Console.WriteLine("Choose payment option:");
            Console.WriteLine("(1) CreditCard");
            Console.WriteLine("(2) IDeal");
            if (key == ConsoleKey.D1)
            {
                if (account.CreditCardInfo is null)
                {
                    Console.Clear();
                    Console.WriteLine("It seems like you don't have a card added to your account, let's add one!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    account.CreditCardInfo = InputCreditCardInfo.CreateCreditCard();
                    AccountDataRW.ChangeAccount(account);
                }
                Console.Clear();
                Console.WriteLine("Do you want to use this card? (Y/N)");
                Console.Write(DisplayCreditCardInfo(account));
                ConsoleKey key1 = Console.ReadKey().Key;

                if (key1 == ConsoleKey.Y)
                {
                    Console.Clear();
                    Console.WriteLine("Okay! We will use this card");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;

                }
                if (key1 == ConsoleKey.N)
                {
                    // what now? lol
                    Console.Clear();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    continue;
                }

            }
            if (key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("You have payed with IDeal");
                Console.ReadKey();
                break;
            }
        }
        flight.Aircraft.BookedSeats.AddRange(seats);
        _flights[_flights.IndexOf(flight)] = flight;
        FlightDataRW.WriteJson(_flights);

        Console.Clear();

        string bookingCode = BookingCode.GenerateCode();
        account.BookedFlights.Add(flight);
        account.BookingCodes.Add(bookingCode);

        Email.SendBookingEmail(account, flight, seats);

        AccountDataRW.ChangeAccount(account);

        Console.WriteLine(@"Thank you so much for booking with Trenlines!
We sent an email with additional information.
Press any key to continue");
        Console.ReadKey();
        LoggedInMenu.LoggedIn(account);
    }
}
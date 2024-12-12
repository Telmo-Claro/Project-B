using System.Text.Json;

public static class Admin
{
    private static bool isLoggedIn = false;

    public static void AdminMenu()
    {
        if (!isLoggedIn)
        {
            if (!AdminLogin())
            {
                Console.WriteLine("\nAccess denied\nPress any key to return to the menu.");
                Console.ReadKey();
                return;
            }

            isLoggedIn = true;
        }


        while (true)
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("TRENLINES - ADMIN PANEL");
            Console.WriteLine("-----------------------");
            Console.WriteLine("(1) View All Flights");
            Console.WriteLine("(2) Add A New Flight");
            Console.WriteLine("(3) Delete A Flight");
            Console.WriteLine("(4) View All Feedback");
            Console.WriteLine("(5) View All Bookings");
            Console.WriteLine("(6) Exit");
            Console.Write("> ");
            string option = Console.ReadKey().KeyChar.ToString();

            if (option == "1")
            {
                ViewFlightsMethod();
            }
            else if (option == "2")
            {
                AddFlight();
            }
            else if (option == "3")
            {
                DeleteFlight();
            }
            else if (option == "4")
            {
                ViewFeedback();
            }
            else if (option == "5")
            {
                ViewBookings();
            }
            else if (option == "6")
            {
                //quit
                isLoggedIn = false;
                break;
            }
            else if (option == "9")
            {
                EditBooking();
            }
            else if (option == "0")
            {
                EditFlight();
            }
        }
    }

    private static bool AdminLogin()
    {
        Console.Clear();
        Console.WriteLine("-----------------------");
        Console.WriteLine("TRENLINES - ADMIN LOGIN");
        Console.WriteLine("-----------------------");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = PasswordTyper.PasswordReadLine();

        if (AdminLogic.AdminLogin(username, password))
        {
            Console.WriteLine("\nAccess granted.\nPress any key to continue.");
            Console.ReadKey();
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void ViewFlightsMethod()
    {
        int page = 1;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Displaying all flights:");
            ViewFlights.View(page);
            Console.WriteLine($"Page: {page}");

            Console.WriteLine("");
            Console.WriteLine("Press X to return to the menu");
            Console.WriteLine("Press S search");
            Console.WriteLine("Press E to edit");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.X)
            {
                break;
            }

            if (key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("Search (leave empty for all):");
                Console.Write("Location: ");
                string? location = Console.ReadLine();
                Console.Write("Date (DD/MM/YYYY): ");
                string? date = Console.ReadLine();
                ViewSearchFlightsMethod(location, date);
                break;
            }
            if (key == ConsoleKey.E)
            {
                EditFlight();
            }
            page = PageScroller.NextPage(Console.ReadKey().Key, page);
        }
    }

    public static void ViewSearchFlightsMethod(string locationSearch, string dateSearch)
    {
        int page = 1;
        while (true)
        {
            Console.Clear();
            ViewFlights.View(page);
            Console.WriteLine("");
            var flights = AdminLogic.ViewAllFlights(page, locationSearch, dateSearch);
            Console.WriteLine($"Page: {page}");
            DisplayFlightList(flights);

            Console.WriteLine("");
            Console.WriteLine("Press X to return to the menu");
            Console.WriteLine("Press S to search again");
            Console.WriteLine("Press E to edit");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.X)
            {
                break;
            }

            if (key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("Search (leave empty for all):");
                Console.Write("Location: ");
                string location = Console.ReadLine();
                Console.Write("Date (DD/MM/YYYY): ");
                string date = Console.ReadLine();
                ViewSearchFlightsMethod(location, date);
                break;
            }

            if (key == ConsoleKey.E)
            {
                EditFlight();
            }
            page = PageScroller.NextPage(Console.ReadKey().Key, page);
        }
    }

    private static void
        DisplayFlightList(
            List<Flight> flights) // als je een x te veel naar rechts gaat, kom je bij de 'else' statement. 
    {
        if (flights != null && flights.Any())
        {
            Console.Clear();
            Console.WriteLine("Displaying searched flights:");
            foreach (var flight in flights)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"Flight details: {flight.FlightNumber} ({flight.Departure} → {flight.Destination}) on {flight.Date:dd/MM/yyyy}");
                Console.WriteLine("");
                Console.ResetColor();
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry, no flights are available matching your criteria.");
            Console.WriteLine("");
            Console.ResetColor();
        }
    }

    public static void DeleteFlight()
    {
        List<Flight> flightList = FlightDataRW.ReadJson();
        Console.Clear();

        while (true)
        {
            Console.WriteLine("Enter the flight number to delete\nType '/Quit' to return to the menu");
            string input = Console.ReadLine();

            if (input == "/Quit")
            {
                return;
            }

            var flightToRemove = AdminLogic.GetFlightDetails(input);
            if (flightToRemove == null)
            {
                Console.Clear();
                Console.WriteLine("No flight found with that number. Please try again.");
                continue;
            }

            Console.Clear();
            Console.WriteLine("Flight Details:");
            Console.WriteLine($"Flight Number: {flightToRemove.FlightNumber}");
            Console.WriteLine($"Departure: {flightToRemove.Departure} → Destination: {flightToRemove.Destination}");
            Console.WriteLine($"Date: {flightToRemove.Date:dd/MM/yyyy}");

            Console.WriteLine("\nPress 1 to continue\nPress 2 to go back");

            string confirmInput = Console.ReadLine();
            if (confirmInput == "2")
            {
                continue;
            }

            if (confirmInput == "1")
            {
                Console.WriteLine(
                    "\nAre you sure you want to delete this flight?\nPress 1 to delete the flight\nPress 2 to cancel");
                confirmInput = Console.ReadLine();

                if (confirmInput == "1")
                {
                    AdminLogic.DeleteFlight(flightToRemove);


                    flightList = FlightDataRW.ReadJson();

                    AdminLogic.DeleteFlight(flightToRemove);
                    Console.Clear();
                    Console.WriteLine("Flight deleted successfully.");
                    Console.WriteLine("");
                    //flightList = FlightDataRW.ReadJson();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Operation cancelled\nReturning to flight selection.");
                    Console.WriteLine("");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Invalid input\nPlease enter 1 to continue or 2 to go back");
            }
        }
    }

    public static void AddFlight()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Enter the flight number to add\nType '/Quit' to return to the menu");
            string input = Console.ReadLine();

            if (input == "/Quit")
            {
                return;
            }

            List<Flight> flightList = FlightDataRW.ReadJson();
            if (flightList.Any(f => f.FlightNumber.Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This flight number already exists");
                continue;
            }

            string departure = "Rotterdam";

            Console.WriteLine("Enter Country:");
            string country = Console.ReadLine();
            if (country == "/Quit")
            {
                return;
            }

            Console.WriteLine("Enter Destination City:");
            string destination = Console.ReadLine();
            if (destination == "/Quit")
            {
                return;
            }

            Console.WriteLine("Enter Date (YYYY-MM-DD):");
            string dateInput = Console.ReadLine();
            DateTime date;
            if (dateInput.Equals("/Quit"))
            {
                return;
            }

            if (!DateTime.TryParse(dateInput, out date))
            {
                Console.WriteLine("Invalid date format. Please enter in YYYY-MM-DD format.");
                continue;
            }

            Console.WriteLine("Enter Time Departure (HH:mm:ss):");
            string timeDepartureInput = Console.ReadLine();
            if (timeDepartureInput.Equals("/Quit"))
            {
                return;
            }

            TimeSpan timeDeparture;
            if (!TimeSpan.TryParse(timeDepartureInput, out timeDeparture))
            {
                Console.WriteLine("Invalid time format. Please enter in HH:mm:ss format.");
                continue;
            }

            Console.WriteLine("Enter Time Arrival (HH:mm:ss):");
            string timeArrivalInput = Console.ReadLine();
            if (timeArrivalInput.Equals("/Quit"))
            {
                return;
            }

            TimeSpan timeArrival;
            if (!TimeSpan.TryParse(timeArrivalInput, out timeArrival))
            {
                Console.WriteLine("Invalid time format. Please enter in HH:mm:ss format.");
                continue;
            }

            Console.WriteLine("Enter Duration (HH:mm:ss):");
            string durationInput = Console.ReadLine();
            if (durationInput.Equals("/Quit"))
            {
                return;
            }

            TimeSpan duration;
            if (!TimeSpan.TryParse(durationInput, out duration))
            {
                Console.WriteLine("Invalid duration format. Please enter in HH:mm:ss format.");
                continue;
            }

            Console.WriteLine("Enter Status:");
            string status = Console.ReadLine();
            if (status.Equals("/Quit"))
            {
                return;
            }

            Console.WriteLine("Choose an aircraft type:");
            Console.WriteLine("1) Boeing 787 (228 seats)");
            Console.WriteLine("2) Airbus 330 (345 seats)");
            Console.WriteLine("3) Boeing 737 (195 seats)");
            string aircraftChoice = Console.ReadLine();
            if (aircraftChoice.Equals("/Quit"))
            {
                return;
            }

            string aircraftName = "";
            int totalSeats = 0;

            switch (aircraftChoice)
            {
                case "1":
                    aircraftName = "Boeing 787";
                    totalSeats = 228;
                    break;
                case "2":
                    aircraftName = "Airbus 330";
                    totalSeats = 345;
                    break;
                case "3":
                    aircraftName = "Boeing 737";
                    totalSeats = 195;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Choose again.");
                    continue;
            }

            Console.WriteLine("Enter the number of seats left (max " + totalSeats + "):");
            int leftSeats;
            while (!int.TryParse(Console.ReadLine(), out leftSeats) || leftSeats < 0 || leftSeats > totalSeats)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 0 and {totalSeats}.");
            }

            Random rnd = new Random();
            Flight newFlight = new Flight
            {
                FlightNumber = input,
                Departure = departure,
                Destination = destination,
                Date = date,
                TimeDeparture = timeDeparture,
                TimeArrival = timeArrival,
                Duration = duration,
                SelectedTimeslots = [],
                Status = status,
                Country = country,
                Aircraft = new Aircraft(totalSeats, aircraftName),
                Price = rnd.Next(50, 200),
            };

            AdminLogic.AddFlight(newFlight);

            Console.Clear();
            Console.WriteLine("You successfully added this flight:");
            Console.WriteLine($"    Flight Number: {newFlight.FlightNumber}");
            Console.WriteLine($"    Departure: {newFlight.Departure}");
            Console.WriteLine($"    Destination: {newFlight.Destination}");
            Console.WriteLine($"    Date: {newFlight.Date:yyyy-MM-dd}");
            Console.WriteLine($"    Time of Departure: {newFlight.TimeDeparture}");
            Console.WriteLine($"    Time of Arrival: {newFlight.TimeArrival}");
            Console.WriteLine($"    Duration: {newFlight.Duration}");
            Console.WriteLine($"    Status: {newFlight.Status}");
            Console.WriteLine($"    Country: {newFlight.Country}");
            Console.WriteLine($"    Aircraft: {newFlight.Aircraft.Name}; ({newFlight.Aircraft.TotalSeats} seats)");
            Console.WriteLine($"    Seats Left: {leftSeats}");
            Console.WriteLine($"    Price: {newFlight.Price}");
            Console.WriteLine("");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public static void ViewFeedback()
    {
        List<Feedback> feedback = AppFeedbackRW.ReadJson();
        Console.Clear();

        foreach (Feedback x in feedback)
        {
            Console.WriteLine(x.FeedbackMessage + "\n ");
        }

        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }

public static void ViewBookings()
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine(new string('=', 26));
    Console.WriteLine("  View All Bookings Menu  ".PadLeft(20).PadRight(20));
    Console.WriteLine(new string('=', 26));
    Console.ResetColor();

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("  Press 'Enter' to view the full list of bookings.");
    Console.WriteLine("  Use the following categories to search for specific values:");
    Console.ResetColor();

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("  Name-based search:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("    - Full Name");
    Console.WriteLine("    - First Name");
    Console.WriteLine("    - Last Name");
    Console.ResetColor();

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("  Flight-related search:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("    - Flight Number");
    Console.WriteLine("    - Departure Date (dd/mm/yyyy)");
    Console.ResetColor();

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("  Location-based search:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("    - Destination");
    Console.ResetColor();

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("");
    Console.WriteLine("'/Quit' to return to the menu.");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("'/Edit' to edit bookings");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(new string('-', 50));
    Console.ResetColor();

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("> ");
    Console.ResetColor();

    string searchText = Console.ReadLine()?.Trim();
    if (searchText.Equals("/Quit", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }
    
    if (searchText.Equals("/Edit"))
    {
        EditBooking();
    }
    
    List<Account> matchingResults = AdminLogic.ViewBookings(searchText);

    if (matchingResults.Any())
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine(new string('=', 26));
        Console.WriteLine("Search Results:".PadLeft(20).PadRight(20));
        Console.WriteLine(new string('=', 26));

        if (string.IsNullOrEmpty(searchText))
        {
            // Empty search -> group destination
            var flightsByDestination = matchingResults
                .Where(a => a.BookedFlights != null && a.BookedFlights.Any())
                .GroupBy(a => a.BookedFlights.First().Destination)
                .ToList();

            Console.WriteLine("Flights by Destination:");
            Console.WriteLine(new string('=', 50));

            foreach (var destinationGroup in flightsByDestination)
            {
                string destination = destinationGroup.Key;
                Console.WriteLine($"\nDestination: {destination}");
                Console.WriteLine(new string('-', 30));

                foreach (var account in destinationGroup)
                {
                    var flight = account.BookedFlights.First();
                    Console.WriteLine($"  Passenger: {account.FirstName} {account.LastName}");
                    Console.WriteLine($"  Booking Code:{flight.BookingCode}");
                    Console.WriteLine($"  Flight Number: {flight.FlightNumber}");
                    
                    Console.WriteLine($"  Departure: {flight.Departure}");
                    Console.WriteLine($"  Date: {flight.Date:dd/MM/yyyy}");
                    Console.WriteLine($"  Departure Time: {flight.TimeDeparture}");
                    
                    
                    // Print seat details
                    Console.WriteLine("  Seats:");
                    foreach (var seat in flight.Seats)
                    {
                        Console.WriteLine($"  Seat ID: {seat.SeatId}");
                        Console.WriteLine($"  Type: {seat.Type}");
                        Console.WriteLine($"  Price: {seat.Price}");
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
            }
        }
        else
        {
            foreach (var account in matchingResults)
            {
                HighlightIfMatch(
                    $"Full Name: {account.FirstName} {account.LastName}",
                    searchText
                );

                foreach (var flight in account.BookedFlights)
                {
                    HighlightIfMatch($"  Flight Number: {flight.FlightNumber}", searchText);
                    HighlightIfMatch($"  Destination: {flight.Destination}", searchText);
                    HighlightIfMatch($"  Date: {flight.Date:dd/MM/yyyy}", searchText);
                    HighlightIfMatch($"  Departure: {flight.Departure}", searchText);
                    HighlightIfMatch($"  Departure Time: {flight.TimeDeparture}", searchText);

                    // Print seat details with highlights
                    HighlightIfMatch("  Seats:", searchText);
                    foreach (var seat in flight.Seats)
                    {
                        HighlightIfMatch($"  Seat ID: {seat.SeatId}", searchText);
                        HighlightIfMatch($"  Type: {seat.Type}", searchText);
                        HighlightIfMatch($"  Price: {seat.Price}", searchText);
                    }

                    Console.WriteLine(new string('-', 40));
                }
            }
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No results match the search criteria.");
        Console.ResetColor();
    }

    Pause();
}

private static void HighlightIfMatch(string fullText, string searchText)
{
    if (fullText.Contains(searchText, StringComparison.OrdinalIgnoreCase))
    {
        int index = fullText.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);
        Console.Write(fullText.Substring(0, index));

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(fullText.Substring(index, searchText.Length));
        Console.ResetColor();

        Console.WriteLine(fullText.Substring(index + searchText.Length));
    }
    else
    {
        Console.WriteLine(fullText);
    }
}

    private static void Pause()
    {
        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

public static void EditBooking()
{
    Console.Clear();
    while (true)
    {
        Console.WriteLine(
            "Enter the booking code to edit the booking\nType '/Quit' to return to the menu");
        string bookingCode = Console.ReadLine();

        if (bookingCode.Equals("/Quit", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        // Get all accounts with their bookings
        List<Account> accounts = AdminLogic.ViewBookings();

        // Find the account and booking associated with the given booking code
        var result = accounts
            .Select(a => new
            {
                Account = a,
                Booking = a.BookedFlights.FirstOrDefault(f => f.BookingCode.Equals(bookingCode, StringComparison.OrdinalIgnoreCase))
            })
            .FirstOrDefault(r => r.Booking != null);

        if (result == null)
        {
            Console.Clear();
            Console.WriteLine("No booking found with that booking code. Please try again.");
            continue;
        }

        Account accountToEdit = result.Account;
        Booking bookingToEdit = result.Booking;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("'/Quit' to return");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Current Booking Details:");
        Console.ResetColor();
        Console.WriteLine($"Passenger: {accountToEdit.FirstName + " " + accountToEdit.LastName}");
        Console.WriteLine($"Booking Code: {bookingToEdit.BookingCode}");
        Console.WriteLine($"Flight Number: {bookingToEdit.FlightNumber}");
        Console.WriteLine($"Departure: {bookingToEdit.Departure}");
        Console.WriteLine($"Destination: {bookingToEdit.Destination}");
        Console.WriteLine($"Date: {bookingToEdit.Date:yyyy-MM-dd}");
        Console.WriteLine($"Departure Time: {bookingToEdit.TimeDeparture}");
        Console.WriteLine($"Arrival Time: {bookingToEdit.TimeArrival}");
        Console.WriteLine($"Catering: {bookingToEdit.Catering}");
        Console.WriteLine();

        foreach (var seat in bookingToEdit.Seats)
        {
            Console.WriteLine($"Seat ID: {seat.SeatId}");
            Console.WriteLine($"Seat Type: {seat.Type}");
            Console.WriteLine($"Seat Price: {seat.Price}");
        }

        while (true)
        {
            Console.WriteLine("\nWhat would you like to edit?");
            //Console.WriteLine("1. Destination");
            //Console.WriteLine("2. Date");
            //Console.WriteLine("3. Departure Time");
            Console.WriteLine("(1) Delete booking");
            Console.WriteLine("(2) Catering");
            Console.WriteLine("(3) Save Changes");
            Console.WriteLine("(4) Cancel");
            Console.Write("> ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                // case "1":
                //     Console.Write("Enter new destination: ");
                //     string newDestination = Console.ReadLine();
                //     if (!string.IsNullOrWhiteSpace(newDestination))
                //     {
                //         bookingToEdit.Destination = newDestination;
                //         Console.WriteLine("Destination updated.");
                //     }
                //     break;
                //
                // case "2":
                //     Console.Write("Enter new date (YYYY-MM-DD): ");
                //     if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                //     {
                //         bookingToEdit.Date = newDate;
                //         Console.WriteLine("Date updated.");
                //     }
                //     else
                //     {
                //         Console.WriteLine("Invalid date format.");
                //     }
                //     break;
                //
                // case "3":
                //     Console.Write("Enter new departure time (HH:mm:ss): ");
                //     if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan newDepartureTime))
                //     {
                //         bookingToEdit.TimeDeparture = newDepartureTime;
                //         Console.WriteLine("Departure time updated.");
                //     }
                //     else
                //     {
                //         Console.WriteLine("Invalid time format.");
                //     }
                //     break;
                //
                // case "4":
                //     Console.Write("Enter new arrival time (HH:mm:ss): ");
                //     if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan newArrivalTime))
                //     {
                //         bookingToEdit.TimeArrival = newArrivalTime;
                //         Console.WriteLine("Arrival time updated.");
                //     }
                //     else
                //     {
                //         Console.WriteLine("Invalid time format.");
                //     }
                //     break;
                case "1":
                    DeleteDelete();
                    break;
                
                case "2":
                    Console.WriteLine("Select a catering option:");
                    Console.WriteLine("(1) Basic");
                    Console.WriteLine("(2) Standard");
                    Console.WriteLine("(3) Premium");
                    Console.WriteLine("(4) No catering");
                    Console.Write("> ");
                    ConsoleKey cateringKey = Console.ReadKey().Key;
                    Console.WriteLine();

                    var (newCatering, isValid) = Catering.GetCatering(cateringKey);
                    if (isValid)
                    {
                        bookingToEdit.Catering = newCatering;
                        Console.WriteLine("Catering option updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid catering option.");
                    }
                    break;

                case "3":
                    AdminLogic.SaveBookings(accountToEdit);
                    Console.Clear();
                    Console.WriteLine("Booking updated successfully.");
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    return;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

public static void EditFlight()
{
    Console.Clear();
    while (true)
    {
        Console.WriteLine("Enter the flight number to edit\nType '/Quit' to return to the menu");
        string flightNumber = Console.ReadLine();

        if (flightNumber == "/Quit")
        {
            return;
        }

        
        List<Flight> flightList = FlightDataRW.ReadJson();
        Flight flightToEdit = flightList.FirstOrDefault(f => f.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase));

        if (flightToEdit == null)
        {
            Console.Clear();
            Console.WriteLine("No flight found with that number. Please try again.");
            continue;
        }
        
        Console.Clear();
        Console.WriteLine("Current Flight Details:");
        Console.WriteLine($"Flight Number: {flightToEdit.FlightNumber}");
        Console.WriteLine($"Current Departure: {flightToEdit.Departure}");
        Console.WriteLine($"Current Destination: {flightToEdit.Destination}");
        Console.WriteLine($"Current Date: {flightToEdit.Date:yyyy-MM-dd}");
        Console.WriteLine($"Current Departure Time: {flightToEdit.TimeDeparture}");
        Console.WriteLine($"Current Arrival Time: {flightToEdit.TimeArrival}");
        Console.WriteLine($"Current Duration: {flightToEdit.Duration}");
        Console.WriteLine($"Current Status: {flightToEdit.Status}");
        Console.WriteLine($"Current Country: {flightToEdit.Country}");
        Console.WriteLine($"Current Aircraft: {flightToEdit.Aircraft.Name}");

        
        while (true)
        {
            Console.WriteLine("\nWhat would you like to edit?");
            Console.WriteLine("1. Destination");
            Console.WriteLine("2. Date");
            Console.WriteLine("3. Departure Time");
            Console.WriteLine("4. Arrival Time");
            Console.WriteLine("5. Duration");
            Console.WriteLine("6. Status");
            Console.WriteLine("7. Country");
            Console.WriteLine("8. Save Changes");
            Console.WriteLine("9. Cancel");
            Console.Write("> ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new destination: ");
                    string newDestination = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newDestination))
                    {
                        flightToEdit.Destination = newDestination;
                        Console.WriteLine("Destination updated.");
                    }
                    break;

                case "2":
                    Console.Write("Enter new date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                    {
                        flightToEdit.Date = newDate;
                        Console.WriteLine("Date updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                    }
                    break;

                case "3":
                    Console.Write("Enter new departure time (HH:mm:ss): ");
                    if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan newDepartureTime))
                    {
                        flightToEdit.TimeDeparture = newDepartureTime;
                        Console.WriteLine("Departure time updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid time format.");
                    }
                    break;

                case "4":
                    Console.Write("Enter new arrival time (HH:mm:ss): ");
                    if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan newArrivalTime))
                    {
                        flightToEdit.TimeArrival = newArrivalTime;
                        Console.WriteLine("Arrival time updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid time format.");
                    }
                    break;

                case "5":
                    Console.Write("Enter new duration (HH:mm:ss): ");
                    if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan newDuration))
                    {
                        flightToEdit.Duration = newDuration;
                        Console.WriteLine("Duration updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid duration format.");
                    }
                    break;

                case "6":
                    Console.Write("Enter new status: ");
                    string newStatus = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newStatus))
                    {
                        flightToEdit.Status = newStatus;
                        Console.WriteLine("Status updated.");
                    }
                    break;

                case "7":
                    Console.Write("Enter new country: ");
                    string newCountry = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCountry))
                    {
                        flightToEdit.Country = newCountry;
                        Console.WriteLine("Country updated.");
                    }
                    break;

                case "8":
                    AdminLogic.UpdateFlight(flightToEdit);
                    Console.Clear();
                    Console.WriteLine("Flight updated successfully.");
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    return;

                case "9":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
public static void AdminDeleteBooking(string firstName, string lastName, string bookingCode)
{
    try
    {
        var accounts = AccountDataRW.ReadFromJson();
        var flights = FlightDataRW.ReadJson();

        if (accounts == null || flights == null)
        {
            Console.WriteLine("Error: Unable to read account or flight data.");
            return;
        }
        
        var account = accounts.FirstOrDefault(a => 
            a.FirstName == firstName && 
            a.LastName == lastName);

        if (account == null)
        {
            Console.WriteLine($"No account found for {firstName} {lastName}");
            return;
        }
        
        var bookingToCancel = account.BookedFlights
            .FirstOrDefault(b => b.BookingCode == bookingCode);

        if (bookingToCancel == null)
        {
            Console.WriteLine($"No booking found with booking code {bookingCode}");
            return;
        }
        
        var correspondingFlight = flights
            .FirstOrDefault(f => f.FlightNumber == bookingToCancel.FlightNumber);

        if (correspondingFlight == null)
        {
            Console.WriteLine($"No flight found for booking {bookingCode}");
            return;
        }
        
        correspondingFlight.Aircraft.BookedSeats = correspondingFlight.Aircraft.BookedSeats
            .Where(seat => !bookingToCancel.Seats.Any(s => s.SeatId == seat.SeatId))
            .ToList();
        
        account.BookedFlights.Remove(bookingToCancel);

        
        var accountIndex = accounts.FindIndex(a => a.FirstName == firstName && a.LastName == lastName);

        if (accountIndex != -1)
        {
            accounts[accountIndex] = account;
        }
        AccountDataRW.WriteToJson(accounts);
        FlightDataRW.WriteJson(flights);
        
        Console.WriteLine($"Successfully deleted booking {bookingCode} for {firstName} {lastName}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"OOOPSY: {ex.Message}");
    }
}

public static void DeleteDelete()
{

    
    Console.WriteLine("Enter the first name of the account holder:");
    Console.Write("> ");
    string firstName = Console.ReadLine().Trim();
    if (firstName.Equals("/Quit", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }
    Console.WriteLine("Enter the last name of the account holder:");
    Console.Write("> ");
    string lastName = Console.ReadLine().Trim();
    if (lastName.Equals("/Quit", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }
    Console.WriteLine("Enter the booking code to delete:");
    Console.Write("> ");
    string bookingCode = Console.ReadLine().Trim().ToUpper();
    if (bookingCode.Equals("/Quit"))
    {
        return;
    }
    
    Console.WriteLine("\nAre you sure you want to delete this booking?");
    Console.WriteLine($"Account: {firstName} {lastName}");
    Console.WriteLine($"Booking Code: {bookingCode}");
    Console.WriteLine("(Y/N)");
    Console.Write("> ");
    
    ConsoleKey key = Console.ReadKey().Key;
    Console.WriteLine();

    if (key == ConsoleKey.Y)
    {
        try
        {
            AdminDeleteBooking(firstName, lastName, bookingCode);
            
            Console.WriteLine("Booking deletion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    else
    {
        Console.WriteLine("Booking deletion cancelled.");
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}
}

    



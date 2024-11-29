public static class Admin
{
    public static void AdminMenu()
    {
        if (!AdminLogin())
        {
            Console.WriteLine("\nAccess denied\nPress any key to return to the menu.");
            Console.ReadKey();
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("TRENLINES - ADMIN PANEL");
            Console.WriteLine("-----------------------");
            Console.WriteLine("(1) View all flights");
            Console.WriteLine("(2) Add a new flight");
            Console.WriteLine("(3) Delete a flight");
            Console.WriteLine("(4) Exit");
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
                break;
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
                 string ?location = Console.ReadLine();
                 Console.Write("Date (DD/MM/YYYY): ");
                 string ?date = Console.ReadLine();
                 ViewSearchFlightsMethod(location, date);
                 break;
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

            page = PageScroller.NextPage(Console.ReadKey().Key, page);
        }
    }
    
    private static void DisplayFlightList(List<Flight> flights) // als je een x te veel naar rechts gaat, kom je bij de 'else' statement. 
    {
        if (flights != null && flights.Any())
        {
            Console.Clear();
            Console.WriteLine("Displaying searched flights:");
            foreach (var flight in flights)
            {
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine($"Flight details: {flight.FlightNumber} ({flight.Departure} → {flight.Destination}) on {flight.Date:dd/MM/yyyy}");
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
            Console.WriteLine("\nAre you sure you want to delete this flight?\nPress 1 to delete the flight\nPress 2 to cancel");
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
}

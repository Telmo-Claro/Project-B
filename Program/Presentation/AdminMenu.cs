using Program.DataAccess;
using Program.DataModels;
using Program.Logic;

namespace Program.Presentation;

public static class Admin
{
    private static readonly string AdminUsername = "snus";
    private static readonly string AdminPassword = "snus";

    public static void AdminMenu()
    {
        if (!AdminLogin())
        {
            Console.WriteLine("");
            Console.WriteLine("Access denied\nPress any key to return to the menu.");
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
        string? username = Console.ReadLine();
        Console.Write("Password: ");
        string? password = Console.ReadLine();

        if (username == AdminUsername && password == AdminPassword)
        {
            Console.WriteLine("");
            Console.WriteLine("Access granted.\nPress any key to continue.");
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

            Console.WriteLine("Press X to return to the menu");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.X)
            {
                break;
            }
            page = PageScroller.NextPage(Console.ReadKey().Key, page);
        }
    }
    
    public static void DeleteFlight()
    {
        List<Flight> flightList = FlightDataRW.ReadJson();
        Console.Clear();

        while (true)
        {
            Console.WriteLine("Enter the flight number to delete\nType '/Quit' to return to the menu");
            string? input = Console.ReadLine();
            if (input == "/Quit") // '/Quit' ipv 'any key' om misclicks te voorkomen. 
            {
                return; 
            }
            Flight? flightToRemove = null;
            
            foreach (var flight in flightList)
            {
                if (flight.FlightNumber != null && flight.FlightNumber.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    flightToRemove = flight;
                    break; 
                } /* ^ Dit stukje zoekt in een lijst van vluchten naar een specifieke vlucht(=input van user)
        wanneer de vlucht is gevonden, wordt deze opgeslagen, en stopt de loop. */
            } 
            
            if (flightToRemove == null) 
            {
                Console.WriteLine("No flight found with that number. Please try again.");
                continue; 
            }
            
            Console.Clear();
            Console.WriteLine("Flight Details:");
            Console.WriteLine($"    Flight Number: {flightToRemove.FlightNumber}");
            Console.WriteLine($"    Departure: {flightToRemove.Departure}");
            Console.WriteLine($"    Destination: {flightToRemove.Destination}");
            Console.WriteLine($"    Date: {flightToRemove.Date}");
            Console.WriteLine($"    Time Departure: {flightToRemove.TimeDeparture}");
            Console.WriteLine($"    Time Arrival: {flightToRemove.TimeArrival}");
            Console.WriteLine($"    Duration: {flightToRemove.Duration}");
            Console.WriteLine($"    Status: {flightToRemove.Status}");
            Console.WriteLine($"    Aircraft:{flightToRemove.Aircraft}");
            Console.WriteLine("\nIf this is the correct flight?\nPress 1 to continue\nPress 2 to go back.");

            string? confirmInput = Console.ReadLine();

            
            if (confirmInput == "2")
            {
                continue; 
            }
            
            if (confirmInput == "1")
            {
                Console.WriteLine("\nAre you sure you want to delete this flight? \n1) Yes\n2) No");
                confirmInput = Console.ReadLine();

                if (confirmInput == "1")
                {
                    flightList.Remove(flightToRemove);
                    FlightDataRW.WriteJson(flightList);
                    Console.WriteLine("Flight deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Operation cancelled. Returning to flight selection.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1 to continue or 2 to go back.");
            }
        }
    }
    public static void AddFlight()
    {
        List<Flight> flightList = FlightDataRW.ReadJson();
        Console.Clear();

        while (true)
        {
            Console.WriteLine("Enter the flight number to add\nType '/Quit' to return to the menu");
            string? input = Console.ReadLine();

            if (input == "/Quit")
            {
                return;
            }
            foreach (var flight in flightList)
            {
                if (flight.FlightNumber != null && flight.FlightNumber.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("This flight number already exists.");
                }
            }

            string departure = "Rotterdam";
        
            Console.WriteLine("Enter Country:");
            string? country = Console.ReadLine();

            Console.WriteLine("Enter Destination City:");
            string? destination = Console.ReadLine();

            Console.WriteLine("Enter Date (YYYY-MM-DD):");
            string? dateInput = Console.ReadLine();
            DateTime date;

            if (!DateTime.TryParse(dateInput, out date))
            {
                Console.WriteLine("Invalid date format. Please enter in YYYY-MM-DD format.");
                continue; 
            }

            Console.WriteLine("Enter Time Departure (HH:mm:ss):");
            string? timeDepartureInput = Console.ReadLine();
            TimeSpan timeDeparture;

            if (!TimeSpan.TryParse(timeDepartureInput, out timeDeparture))
            {
                Console.WriteLine("Invalid time format. Please enter in HH:mm:ss format.");
                continue; 
            }

            Console.WriteLine("Enter Time Arrival (HH:mm:ss):");
            string? timeArrivalInput = Console.ReadLine();
            TimeSpan timeArrival;

            if (!TimeSpan.TryParse(timeArrivalInput, out timeArrival))
            {
                Console.WriteLine("Invalid time format. Please enter in HH:mm:ss format.");
                continue; 
            }

            Console.WriteLine("Enter Duration (HH:mm:ss):");
            string? durationInput = Console.ReadLine();
            TimeSpan duration;

            if (!TimeSpan.TryParse(durationInput, out duration))
            {
                Console.WriteLine("Invalid duration format. Please enter in HH:mm:ss format.");
                continue; 
            }

            Console.WriteLine("Enter Status:");
            string? status = Console.ReadLine();
        
            Console.WriteLine("Choose an aircraft type:");
            Console.WriteLine("1) Boeing 787 (228 seats)");
            Console.WriteLine("2) Airbus 330 (345 seats)");
            Console.WriteLine("3) Boeing 737 (195 seats)");
            string? aircraftChoice = Console.ReadLine();

            string? aircraftName;
            int totalSeats;

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
                    Console.WriteLine("Invalid choice. Flight not added.");
                    continue;
            }

            Console.WriteLine("Enter the number of seats left (max " + totalSeats + "):");
            int leftSeats;
            while (!int.TryParse(Console.ReadLine(), out leftSeats) || leftSeats < 0 || leftSeats > totalSeats)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 0 and {totalSeats}.");
            }

        
            Flight newFlight = new Flight
            {
                FlightNumber = input,
                Departure = departure,
                Destination = destination,
                Date = date,
                TimeDeparture = timeDeparture,
                TimeArrival = timeArrival,
                Duration = duration,
                Status = status,
                Country = country, 
                Aircraft = new Aircraft(totalSeats, aircraftName) 
            };

            flightList.Add(newFlight);
            FlightDataRW.WriteJson(flightList);
            Console.WriteLine("Flight added successfully.");
        }
    }
}
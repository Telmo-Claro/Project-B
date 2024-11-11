public static class Menu
{
    public static void WelcomingMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("WELCOME TO TRENLINES!");
            Console.WriteLine("---------------------");

            Console.WriteLine("What do you wish to do:");
            Console.WriteLine("(1) Log in");
            Console.WriteLine("(2) Create an account");
            Console.WriteLine("(3) Exit");
            Console.Write("> ");
            string option = Console.ReadKey().KeyChar.ToString();
            switch (option)
            {
                case "1":
                    LoginMenu();
                    break;
                case "2":
                    CreateAccountMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
        // ReSharper disable once FunctionNeverReturns
    }

    public static void LoginMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("------------------");
            Console.WriteLine("TRENLINES - LOG IN");
            Console.WriteLine("------------------");

            Console.WriteLine("Enter email [Q to exit]");
            string? email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email) || email.ToLower() == "q")
            {
                break;
            }

            // Check if email contains '@'
            if (!email.Contains("@"))
            {
                Console.WriteLine("Invalid email. Please ensure it contains an '@'.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine("Enter password [Q to exit]");
            string? password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password) || password.ToLower() == "q")
            {
                break;
            }

            // Call LoggingIn and check for null result
            var account = AccountDataRW.LoggingIn(email, password);
            if (account != null)
            {
                LoggedInMenu(account);
            }
            else
            {
                Console.WriteLine("Invalid email or password. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    public static void LoggedInMenu(Account? account)
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
                    BookFlightMenu();
                    break;
                case "2" :
                    var bookingChoice = BookingMenu(account);
                    AccountDataRW.Booking(account, bookingChoice);
                    //ViewBookedFlights.PrintBookedFlight(account.BookedFlights);
                    break;
                case "3":
                    ManageAccount(account);
                    break;
                case "4":
                    DeleteAccount(account);
                    break;
                case "5":
                    WelcomingMenu();
                    break;
                case "6":
                    LoggedInMenu(account);
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
    
    private static void DeleteAccount(Account? account)
    {
        try
        {
            AccountDataRW.DeleteAccount(account.Email);
            Console.WriteLine("Account deleted successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
        Console.ReadKey();
    }
    
    public static void ManageAccount(Account? account)
    {
        try
        {
            DisplayAccountInfo(account);
            Console.WriteLine("(1) Change name");
            Console.WriteLine("(2) Change email");
            Console.WriteLine("(3) Change phone number");
            Console.WriteLine("(4) Change password");
            Console.WriteLine("(5) View CreditCard information");
            Console.WriteLine("(6) Go back");

            int choice;
            bool valid = false;
            while (!valid)
            {
                Console.Write("Please enter an option: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    AccountDataRW.ChangeData(account, choice);
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
        Console.ReadKey();
    }

    public static void ShowActiveBookings(Account account)
    {
        Console.Clear();
        Console.WriteLine($"----------------------");
        Console.WriteLine($"Current booked flights");
        Console.WriteLine($"----------------------");
        foreach (var flight in account.BookedFlights)
        {
            if (flight.Status == "Planned")
            {
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
            if (flight.Status == "Departed")
            {
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

    public static string? BookingMenu(Account? account)
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
    
    public static void DisplayAccountInfo(Account? account)
    {
        Console.Clear();
        Console.WriteLine("---------------- TRENLINES -----------------");
        Console.WriteLine($"Account name: {account.FirstName} {account.LastName}");
        Console.WriteLine($"Account email: {account.Email}");
        Console.WriteLine($"Account phone number: {account.PhoneNumber}");
        Console.WriteLine("--------------------------------------------");
    }

    public static void DisplayCreditCardInfo(Account? account)
    {
        Console.Clear();
        Console.WriteLine("---------------- TRENLINES -----------------");
        Console.WriteLine($"CreditCard name: {account.CreditCardInfo.FirstName} {account.CreditCardInfo.FirstName}");
        Console.WriteLine($"CreditCard number: {account.CreditCardInfo.Number}");
        Console.WriteLine($"CreditCard Expiration Date: {account.CreditCardInfo.ExpirationDate}");
        Console.WriteLine($"CreditCard CVC: {account.CreditCardInfo.CvcCode}");
        Console.WriteLine("--------------------------------------------");
    }

    public static void DisplayFlightInfo(Flight? flight)
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

    public static void CreateAccountMenu()
    {
        while (true)
        {
            string? firstName = "";
            string? lastName = "";
            string? email = "";
            string? password = "";
            string? phoneNumber = "";
            CreditCard? creditCard = null;
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("TRENLINES - CREATE ACCOUNT");
            Console.WriteLine("--------------------------");
            while (firstName == "")
            {
                Console.Write("First name: ");
                firstName = Console.ReadLine();
            }

            while (lastName == "")
            {
                Console.Write("Last name: ");
                lastName = Console.ReadLine();
            }

            while (email == "")
            {
                Console.Write("Enter email: ");
                email = Console.ReadLine();
            }

            while (phoneNumber == "")
            {
                Console.Write("Phone number: ");
                phoneNumber = Console.ReadLine();
            }

            while (password == "")
            {
                Console.Write("Enter password: ");
                password = Console.ReadLine();
            }

            bool choice = false;
            Console.Write("Do you want to add a CreditCard? Y/N: ");
            choice = Console.ReadKey().KeyChar.ToString().ToUpper() == "Y" ? true : false;
            if (choice)
            {
                creditCard = ClassFactory.CreateCreditCard();
            }

            if (firstName != null && lastName != null
                                  && email != null && phoneNumber != null
                                  && password != null)
            {
                // firstName, lastName, email, phoneNumber, password
                Account? account = ClassFactory.CreateAccount(firstName, lastName, email, phoneNumber, password);
                if (choice)
                {
                    account.CreditCardInfo = creditCard;
                }
                AccountDataRW.WriteJson(account);
                LoggedInMenu(account);

            }
            break;
        }
    }
    public static void ViewFlightMenu()
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
            ViewFlights.View(page);
            Console.WriteLine("--------------");
            Console.WriteLine($"Page: {page}");
            Console.WriteLine("--------------");
            Console.WriteLine("Press S search");
            Console.WriteLine("To book a flight call: 010420777");
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
                ViewSearchFlightsMenu(location, date);
                break;
            }
        }
    }

    public static void ViewSearchFlightsMenu(string ?locationSearch, string ?dateSearch)
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
            Console.WriteLine("To book a flight call: 010420777");
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
                ViewSearchFlightsMenu(location, date);
                break;
            }
        }
    }
    public static void BookFlightMenu()
    {
        ViewFlightMenu();
        // implement booking
    }
}
using System.Net;
using System.Runtime.CompilerServices;

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
                case "p":
                    Admin.AdminMenu();
                    break;
                //case "z":
                //    OverviewAirbus330.Display330();
                //    break;
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
                    ViewFlightMenu(account);
                    break;
                case "2":
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


    public static string DisplayCreditCardInfo(Account? account)
    {
        return "---------------- TRENLINES -----------------\n" +
            $"CreditCard Name: {account.CreditCardInfo.FirstName} {account.CreditCardInfo.LastName}\n" +
            $"CreditCard Number: {account.CreditCardInfo.Number}\n" +
            $"CreditCard Expiration Date: {account.CreditCardInfo.ExpirationDate}\n" +
            $"CreditCard CVC: {account.CreditCardInfo.CvcCode}\n" +
            "--------------------------------------------\n";
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
                Console.Clear();
                creditCard = InputCreditCardInfo.CreateCreditCard();
            }

            if (firstName != null && lastName != null
                                  && email != null && phoneNumber != null
                                  && password != null)
            {
                // firstName, lastName, email, phoneNumber, password
                Account? account = ClassFactory.CreateAccount(firstName, lastName, email, phoneNumber, password, creditCard);
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

    public static void ViewSearchFlightsMenu(string? locationSearch, string? dateSearch, Account account)
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

        List<Seat> seats = [];
        switch (flight.Aircraft.Name)
        {
            case "Airbus 330":
                {
                    break;
                }
            case "Boeing 737":
                {
                    seats = OverviewBoeing737.Display737(flight);
                    break;
                }
            case "Boeing 787":
                {
                    seats = OverviewBoeing787.Display787(flight);
                    break;
                }
        }

        int totalprice = Price.GetPrice(flight, seats);
        Console.WriteLine($@"The costs will be {totalprice}
Press any key to continue.");
        Console.ReadKey();

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

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Do you want to use this card? (Y/N)");
            Console.Write(DisplayCreditCardInfo(account));
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.Y)
            {
                Console.Clear();
                Console.WriteLine("Okay! We will use this card");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                // add something extra for payment?
                break;
            }
            if (key == ConsoleKey.N)
            {
                // what now? lol
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                break;
            }
        }

        Console.Clear();

        string bookingCode = BookingCode.GenerateCode();
        account.BookedFlights.Add(flight);
        account.BookingCodes.Add(bookingCode);

        // Email.SendEmail(account, flight, bookingCode);

        AccountDataRW.ChangeAccount(account);

        Console.WriteLine(@"Thank you so much for booking with Trenlines!
We sent an email with additional information.
Press any key to continue");
        Console.ReadKey();
        LoggedInMenu(account);
    }
}
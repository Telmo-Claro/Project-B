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
            if (option == "1")
            {
                LoginMenu();
            }
            else if (option == "2")
            {
                CreatAccountMenu();
            }
            else if (option == "3")
            {
                Environment.Exit(0);
            }
            else if (option == "4")
            {
                LoginMenu();
            }
            else if (option == "p")
            {
                Admin.AdminMenu();
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
            Console.WriteLine("(2) View booking history");
            Console.WriteLine("(3) Manage account");
            Console.WriteLine("(4) Delete account");
            Console.WriteLine("(5) Exit");

            string input = Console.ReadKey().KeyChar.ToString();

            switch (input)
            {
                case "1":
                    ViewFlightMenu();
                    break;
                case "2" :
                    ViewBookedFlights.PrintBookedFlight(account.BookedFlights);
                    break;
                case "3":
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
                            try
                            {
                                choice = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                                AccountDataRW.ChangeData(account, choice);
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    Console.ReadKey();
                    break;
                case "4":
                    try
                    {
                        AccountDataRW.DeleteAccount(account.Email);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    break;
                case "5":
                    WelcomingMenu();
                    break;
                case "6":
                    LoggedInMenu(account);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    Console.ReadKey();
                    break;
            }
        }
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

    public static void CreatAccountMenu()
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
                ViewSearchFlightsMenu(location, date);
                break;
            }
            if (key == ConsoleKey.B)
            {
                BookFlightMenu();
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
                ViewSearchFlightsMenu(location, date);
                break;
            }
            if (key == ConsoleKey.B)
            {
                BookFlightMenu();
            }
        }
    }
    private static readonly List<Flight> _flights = FlightDataRW.ReadJson();
    public static void BookFlightMenu()
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

                if (key == ConsoleKey.Y)
                {
                    Console.WriteLine("boookkkkkk");
                    Console.ReadKey();
                    // book implementation
                    break;
                }
                        
                if (key == ConsoleKey.N)
                {
                    ViewFlightMenu();
                }                    
                else
                {
                    Console.WriteLine("Wrong input, please make sure the flightnumber is correct");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    ViewFlightMenu();
                }
            }
        }


    }
}
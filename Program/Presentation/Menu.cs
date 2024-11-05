using System.Runtime.CompilerServices;
using System;
using System.Diagnostics;

public static class Menu
{
    public static void welcomingMenu()
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
                loginMenu();
            }
            else if (option == "2")
            {
                creatAccountMenu();
            }
            else if (option == "3")
            {
                Environment.Exit(0);
            }
            else if (option == "4")
            {
                loginMenu();
            }
            else if (option == "p")
            {
                Admin.AdminMenu();
            }
        }
    }

    public static void loginMenu()
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
                loggedInMenu(account);
            }
            else
            {
                Console.WriteLine("Invalid email or password. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }


    public static void loggedInMenu(Account account)
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
                    bookFlightMenu();
                    break;
                case "2" :
                    ViewBookedFlights.PrintBookedFlight(account.bookedFlights);
                    break;
                case "3":
                    try
                    {
                        DisplayAccountInfo(account);
                        Console.WriteLine("(1) Change name");
                        Console.WriteLine("(2) Change email");
                        Console.WriteLine("(3) Change phone number");
                        Console.WriteLine("(4) Change password");
                        Console.WriteLine("(5) Change payment method");
                        Console.WriteLine("(6) Go back");

                        int choice  = 0;
                        bool valid = false;
                        while (!valid)
                        {
                            Console.Write("Please enter an option: ");
                            try
                            {
                                choice = int.Parse(Console.ReadLine());
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
                    welcomingMenu();
                    break;
                case "6":
                    loggedInMenu(account);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    Console.ReadKey();
                    break;
            }
        }
    }

    public static void DisplayAccountInfo(Account account)
    {
        Console.Clear();
        Console.WriteLine("---------------- TRENLINES -----------------");
        Console.WriteLine($"Account name: {account.FirstName} {account.LastName}");
        Console.WriteLine($"Account email: {account.Email}");
        Console.WriteLine($"Account phone number: {account.PhoneNumber}");
        Console.WriteLine($"Account payment method: {account.PaymentMethod}");
        Console.WriteLine("--------------------------------------------");
    }
    public static void creatAccountMenu()
    {
        while (true)
        {
            string? firstName = "";
            string? lastName = "";
            string? email = "";
            string? password = "";
            string? phoneNumber = "";
            string? paymentMethod = "";
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

            while (paymentMethod == "")
            {
                Console.Write("Enter payment method [IDeal or CreditCard]: ");
                paymentMethod = Console.ReadLine();
            }

            if (firstName != null && lastName != null && email != null && phoneNumber != null && password != null && paymentMethod != null)
            {
                Account account = new Account(firstName, lastName, email, phoneNumber, password, paymentMethod);
                AccountDataRW.WriteJson(account);

                loggedInMenu(account);
            }
            break;
        }
    }

    public static void bookFlightMenu()
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
            Console.WriteLine("To book a flight call: 010420777");
            ConsoleKey Key = Console.ReadKey().Key;
            page = PageScroller.NextPage(Key, page);
            if (Key == ConsoleKey.Escape || Key == ConsoleKey.Tab) { break; }
            // implement bookFlight
        }
    }
}
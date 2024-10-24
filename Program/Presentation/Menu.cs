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
            Console.WriteLine("------------------------------");
            Console.WriteLine("WELCOME TO ROTTERDAM AIRLINES!");
            Console.WriteLine("------------------------------");

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
            Console.WriteLine("---------------------------");
            Console.WriteLine("ROTTERDAM AIRLINES - LOG IN");
            Console.WriteLine("---------------------------");

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
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"ROTTERDAM AIRLINES - Welcome {account.FirstName}!");
            Console.WriteLine("------------------------------------");

            Console.WriteLine("What do you wish to do:");
            Console.WriteLine("(1) View and book flights");
            Console.WriteLine("(2) View booking history");
            Console.WriteLine("(3) Change account information");
            Console.WriteLine("(4) Delete account");
            Console.WriteLine("(5) Exit");
            string option = Console.ReadKey().KeyChar.ToString();

            if (option == "1")
            {
                bookFlightMenu();
            }
            else if (option == "2")
            {
                ViewBookedFlights.PrintBookedFlight(account.bookedFlights);
                // string youtubeUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                // Process.Start(new ProcessStartInfo
                // {
                //     FileName = youtubeUrl,
                //     UseShellExecute = true
                // });
            }
            else if (option == "3")
            {
                AccountDataRW.ChangeData(account);
            }
            else if (option == "4")
            {
                AccountDataRW.DeleteAccount(account.Email);
            }
            else if (option == "5")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong input");
                Console.ReadKey();
            }

        }
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
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("ROTTERDAM AIRLINES - CREATE ACCOUNT");
            Console.WriteLine("-----------------------------------");
            while (firstName == "")
            {
                Console.WriteLine("First name: ");
                firstName = Console.ReadLine();
            }

            while (lastName == "")
            {
                Console.WriteLine("Last name: ");
                lastName = Console.ReadLine();
            }

            while (email == "")
            {
                Console.WriteLine("Enter email: ");
                email = Console.ReadLine();
            }
            while (phoneNumber == "")
            {
                Console.WriteLine("Phone number: ");
                phoneNumber = Console.ReadLine();
            }

            while (password == "")
            {
                Console.WriteLine("Enter password: ");
                password = Console.ReadLine();
            }

            if (firstName != null && lastName != null && email != null && phoneNumber != null && password != null)
            {
                Account account = new Account(firstName, lastName, email, phoneNumber, password);
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
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("ROTTERDAM AIRLINES - BOOKING A FLIGHT");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("               Flights               ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("FlightNumber|Departure|Destination|   Date   |TimeDeparture|TimeArrival|Duration|    Country    |   Aircraft  | Status");
            ViewFlights.View(page);
            Console.WriteLine("--------------");
            Console.WriteLine($"Page: {page}");
            Console.WriteLine("--------------");
            Console.WriteLine("To book a flight call: 010420777");
            ConsoleKey Key = Console.ReadKey().Key;
            page = PageScroller.NextPage(Key, page);
            if (Key == ConsoleKey.Escape) { break; }
            // implement bookFlight
        }
    }
}
using System.Runtime.CompilerServices;

public static class Menu
{
    public static void welcomingMenu()
    {
        while (true) {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("WELCOME TO ROTTERDAM AIRLINES!");
            Console.WriteLine("------------------------------");

            Console.WriteLine("What do you wish to do:");
            Console.WriteLine("(1) Log in.");
            Console.WriteLine("(2) Create an account.");
            Console.WriteLine("(3) Exit.");
            Console.Write("> ");
            string option = Console.ReadKey().KeyChar.ToString();
            if(option == "1")
            {
                loginMenu();
            }
            else if(option == "2")
            {
                creatAccountMenu();
            }
            else if(option == "3")
            {
                Environment.Exit(0);
            }
        }
    }

    public static void loginMenu()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("ROTTERDAM AIRLINES - LOG IN");
            Console.WriteLine("---------------------------");
            
            Console.WriteLine("Enter email [Q to exit]");
            string email = Console.ReadLine();
            if(email == "q")
            {
                break;
            }

            Console.WriteLine("Enter password [Q to exit]");
            string password = Console.ReadLine();
            if(password == "q")
            {
                break;
            }
            // implement login function
        }
    }

    public static void loggedInMenu()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("ROTTERDAM AIRLINES - WELCOME {USER}!");
            Console.WriteLine("------------------------------------");
            
            Console.WriteLine("What do you wish to do:");
            Console.WriteLine("(1) View and book flights.");
            Console.WriteLine("(2) View booking history.");
            Console.WriteLine("(3) Change account information.");
            Console.WriteLine("(4) Delete account.");
            Console.WriteLine("(5) Exit.");
            // implement login function
        }
    } 

    public static void creatAccountMenu()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("ROTTERDAM AIRLINES - CREATE ACCOUNT");
            Console.WriteLine("-----------------------------------");
            
            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Phone number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine);
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            // implement create account function
        }
    }

    public static void bookFlightMenu()
    {
        int page = 1;
        while(true)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("ROTTERDAM AIRLINES - BOOKING A FLIGHT");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("               Flights               ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("FlightNumber|Departure|Destination|   Date   |TimeDeparture|TimeArrival|Duration|    Country    |Aircraft");
            ViewFlights.View(page);
            Console.WriteLine("--------------");
            Console.WriteLine($"Page: {page}");
            Console.WriteLine("--------------");
            Console.WriteLine("To book a flight call: 010420777");
            page = PageScroller.NextPage(Console.ReadKey().Key, page);
            // implement bookFlight
        }
    }
}

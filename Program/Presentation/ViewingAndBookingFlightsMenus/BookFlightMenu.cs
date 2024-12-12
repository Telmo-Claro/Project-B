public static class BookFlightMenu
{
    private static readonly List<Flight> _flights = FlightDataRW.ReadJson();
    public static void BookingMenu(Account account)
    {
        Console.Clear();
        Console.WriteLine("What is the flight number from the flight you would like to book?");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Type 'Exit' to go back");
        Console.ResetColor();
        Console.Write("> ");
        string? givenFlightNumber = Console.ReadLine().ToUpper();
        if (givenFlightNumber.Equals("Exit"))
        {
            return;
        }
        foreach (Flight flight in _flights)
        {
            if (flight.FlightNumber == givenFlightNumber) //legit 3 lines of code and u couldnt do it earlier fellas...
            {
                if (flight.Status != "Planned")
                {
                    Console.Clear();
                    Console.WriteLine("This flight cannot be booked.");
                    Console.WriteLine($"Current flight status: {flight.Status}");
                    Console.WriteLine("Only flights with 'Planned' status can be booked.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    BookingMenu(account);
                    return;
                }

                Console.Clear();
                Console.WriteLine("Is this the flight you would like to book?");
                Console.WriteLine($"Flightnumber: {flight.FlightNumber}");
                Console.WriteLine($"Departure: {flight.Departure}");
                Console.WriteLine($"Destination: {flight.Destination}");
                Console.WriteLine($"Date: {flight.Date}");
                Console.WriteLine($"Departure time: {flight.TimeDeparture}");
                Console.WriteLine($"Arrival time: {flight.TimeArrival}");
                Console.WriteLine($"Duration: {flight.Duration}");
                Console.WriteLine("Correct flight? (Y/N)");
                Console.Write("> ");
                
                ConsoleKey key = Console.ReadKey().Key;
                while (true)
                {
                    if (key == ConsoleKey.Y)
                    {
                        FlightBooking.BookFlight(account, flight);
                    }

                    else if (key == ConsoleKey.N)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Make sure you enter the correct flight number.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        BookingMenu(account);
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
}
public static class BookFlightMenu
{
    private static readonly List<Flight> _flights = FlightDataRW.ReadJson();
    public static void BookingMenu(Account account)
    {
        Console.Clear();
        Console.WriteLine("What is the flight number from the flight you would like to book?");
        Console.Write("> ");
        string? givenFlightNumber = Console.ReadLine().ToUpper();

        foreach (Flight flight in _flights)
        {
            if (flight.FlightNumber == givenFlightNumber)
            {
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
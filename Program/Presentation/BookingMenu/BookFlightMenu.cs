public static class BookFlightMenu
{
    private static readonly List<Flight> _flights = FlightDataRW.ReadJson();
    public static void BookingMenu(Account account)
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
                        FlightBooking.BookFlight(account, flight);
                    }

                    else if (key == ConsoleKey.N)
                    {
                        Console.WriteLine(@"Make sure you enter the correct flightnumber.
Press any key to continue.");
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
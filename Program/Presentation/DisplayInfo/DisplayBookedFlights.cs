public static class DisplayBookedFlights
{
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

        Console.WriteLine("Would you like to book a special experience with one of the booked flights?");
        Console.WriteLine("(1) Yes");
        Console.WriteLine("(2) No");
        ConsoleKey key = Console.ReadKey().Key;
        Console.Clear();
        if (key == ConsoleKey.D1)
        {
            Console.WriteLine("What is the Flight Number of the flight you would like to add a special experience to?");
            while (true)
            {
                string? chosenNumber = Console.ReadLine();

                foreach (Flight vlucht in account.BookedFlights)
                {
                    if (vlucht.FlightNumber == chosenNumber)
                    {
                        FlightExperiencePres.FlightExperience(vlucht);
                        return;
                    }
                }
                Console.WriteLine("That Flight Number does not match any of your booked flights.\nPlease enter a valid booked Flight Number.");
            }
        }
        else
        {
            MainBookingPresentation.DisplayMenu(account);
        }
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
        MainBookingPresentation.DisplayMenu(account);
    }
}
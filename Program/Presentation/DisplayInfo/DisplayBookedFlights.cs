public static class DisplayBookedFlights
{
    public static void ShowActiveBookings(Account account)
    {
        List<Flight> flights = FlightDataRW.ReadJson();
        Console.Clear();
        Console.WriteLine($"----------------------");
        Console.WriteLine($"Current booked flights");
        Console.WriteLine($"----------------------");
        foreach (var booking in account.BookedFlights)
        {
            if (null != flights.FirstOrDefault(flight => flight.FlightNumber == booking.FlightNumber && flight.Status == "Planned"))
            {
                Console.WriteLine(booking);
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
            }
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();

        if (account.BookedFlights is not [])
        {
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

                    foreach (Booking booking in account.BookedFlights)
                    {
                        if (booking.FlightNumber == chosenNumber)
                        {
                            FlightExperiencePres.FlightExperience(chosenNumber);
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
    }
    public static void ShowPastFlights(Account account)
    {
        List<Flight> flights = FlightDataRW.ReadJson();
        Console.Clear();
        Console.WriteLine($"----------------------");
        Console.WriteLine($"Past flights");
        Console.WriteLine($"----------------------");
        foreach (var booking in account.BookedFlights)
        {
            if (null != flights.FirstOrDefault(flight => flight.FlightNumber == booking.FlightNumber && flight.Status == "Departed"))
            {
                Console.WriteLine(booking);
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        MainBookingPresentation.DisplayMenu(account);
    }
}
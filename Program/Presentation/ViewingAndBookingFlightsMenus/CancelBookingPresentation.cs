public static class CancelBookingPresentation
{
        public static void CancelBooking(Account account)
    {
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

        bool choicemade = false;
        string choice = "";
        while (!choicemade)
        {
            Console.WriteLine("Do you want to cancel booking? [Y/N]");
            string key = Console.ReadKey().Key.ToString();
            switch (key.ToLower())
            {
                case "y":
                    choice = "y";
                    choicemade = true;
                    break;
                case "n":
                    choice = "n";
                    choicemade = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
            Console.WriteLine();
        }

        switch (choice.ToLower())
        {
            case "y":
                Console.Write("Enter the flight number you want to cancel: ");
                string flightNumber = Console.ReadLine();
                // Here telmo!
                CancelBookingLogic.CancelBooking(account, flightNumber);
                Console.WriteLine("Booking cancelled successfully!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            case "n":
                MainBookingPresentation.DisplayMenu(account);
                break;
        }

    }
}
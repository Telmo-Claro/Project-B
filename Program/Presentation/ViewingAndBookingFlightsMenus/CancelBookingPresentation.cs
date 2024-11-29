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
        var choice = "";
        
        while (!choicemade)
        {
            Console.WriteLine("Do you want to cancel booking? [Y/N]");
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.Y:
                    choice = "y";
                    choicemade = true;
                    break;
                case ConsoleKey.N:
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
                Console.WriteLine("Enter the flight number you want to cancel [eg. TREN0007]");
                Console.Write("> ");
                string flightNumber = Console.ReadLine();
                bool valid = CancelBookingLogic.ValidFlight(account, flightNumber);
                if (!valid)
                {
                    Console.WriteLine("Flight not found!");
                    CancelBookingPresentation.CancelBooking(account);
                }
                else
                {
                    bool canGetRefund = CancelBookingLogic.CanGetRefund(account, flightNumber);
                    if (canGetRefund)
                    {
                        foreach (var flight in account.BookedFlights)
                        {
                            if (flight.FlightNumber == flightNumber)
                            {
                                Console.WriteLine("Booking cancelled successfully!");
                                Console.WriteLine($"€{flight.Price} will be refunded!");
                                Thread.Sleep(2000);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Booking cancelled successfully!");
                        Thread.Sleep(2000);
                        Console.WriteLine($"You cancelled the booking too late");
                        Thread.Sleep(2000);
                        Console.WriteLine($"No refund for you!");
                        Thread.Sleep(2000);
                    }
                    CancelBookingLogic.CancelBooking(account, flightNumber);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            case "n":
                MainBookingPresentation.DisplayMenu(account);
                break;
        }

    }
}
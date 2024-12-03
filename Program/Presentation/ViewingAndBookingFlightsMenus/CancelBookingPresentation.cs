public static class CancelBookingPresentation
{
    public static void CancelBooking(Account account)
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

        bool choicemade = false;
        var choice = "";
        
        if (account.BookedFlights is not [])
        {
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
                    Console.WriteLine("Enter the booking number you want to cancel");
                    Console.Write("> ");
                    string bookingnumber = Console.ReadLine();
                    bool valid = CancelBookingLogic.ValidFlight(account, bookingnumber);
                    if (!valid)
                    {
                        Console.WriteLine("Flight not found!");
                        CancelBookingPresentation.CancelBooking(account);
                    }
                    else
                    {
                        bool canGetRefund = CancelBookingLogic.CanGetRefund(account, bookingnumber);
                        if (canGetRefund)
                        {
                            foreach (var flight in account.BookedFlights)
                            {
                                if (flight.FlightNumber == bookingnumber)
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
                        CancelBookingLogic.CancelBooking(account, bookingnumber);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "n":
                    MainBookingPresentation.DisplayMenu(account);
                    break;
            }
        }
        else
        {
            Console.WriteLine("You don't have any bookings you can cancel.");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();

    }
}
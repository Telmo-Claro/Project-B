public static class FlightBooking
{
    private static readonly List<Flight> _flights = FlightDataRW.ReadJson();

    public static void BookFlight(Account account, Flight flight)
    {

        List<Seat> seats = [];
        seats = BookingLogic.GetSeats(flight);

        if (seats.Count == 0) { return; }
        Console.WriteLine("if you are interested in the special experience press (1), you will be contacted about further details.");
        Console.ReadKey();
        Console.Clear();

        int totalprice = Price.GetTotalPrice(flight, seats);
        int seatPrices = Price.GetSeatPrices(seats);
        Console.WriteLine($@"The costs will be �{totalprice}
Tren tax: 50
Total seat price: {seatPrices}
Flight price: {flight.Price}
Press any key to continue.");
        Console.ReadKey();

        while (true)
        {
            ConsoleKey key = Console.ReadKey().Key;
            Console.Clear();
            Console.WriteLine("Choose payment option:");
            Console.WriteLine("(1) CreditCard");
            Console.WriteLine("(2) IDeal");
            if (key == ConsoleKey.D1)
            {
                if (account.CreditCardInfo is null)
                {
                    Console.Clear();
                    Console.WriteLine("It seems like you don't have a card added to your account, let's add one!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    account.CreditCardInfo = InputCreditCardInfo.CreateCreditCard();
                    AccountDataRW.ChangeAccount(account);
                }
                Console.Clear();
                Console.WriteLine("Do you want to use this card? (Y/N)");
                Console.Write(DisplayCreditCardInfo.CreditCardInfo(account));
                ConsoleKey key1 = Console.ReadKey().Key;

                if (key1 == ConsoleKey.Y)
                {
                    Console.Clear();
                    Console.WriteLine("Okay! We will use this card");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;

                }
                if (key1 == ConsoleKey.N)
                {
                    // what now? lol
                    Console.Clear();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    continue;
                }

            }
            if (key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("You have payed with IDeal");
                Console.ReadKey();
                break;
            }
        }
        flight.Aircraft.BookedSeats.AddRange(seats);

        int index = _flights.FindIndex(f => f.FlightNumber == flight.FlightNumber);
        if (index != -1)
        {
            _flights[index] = flight;
        }
        else
        {
            Console.WriteLine("Flight not found in the list.");
        }

        FlightDataRW.WriteJson(_flights);

        Console.Clear();

        string bookingCode = BookingCode.GenerateCode();
        account.BookedFlights.Add(flight);
        account.BookingCodes.Add(bookingCode);

        Email.SendBookingEmail(account, flight, seats);

        AccountDataRW.ChangeAccount(account);

        Console.WriteLine(@"Thank you so much for booking with Trenlines!
We sent an email with additional information.
Press any key to continue");
        Console.ReadKey();
        LoggedInMenu.LoggedIn(account);
    }
}
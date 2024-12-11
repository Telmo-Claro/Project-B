using System.Security.Cryptography.X509Certificates;

public static class FlightBooking
{
    private static readonly List<Flight> _flights = FlightDataRW.ReadJson();
    public static bool FlightExperienceBool = false;

    public static void BookFlight(Account account, Flight flight)
    {
        List<Seat> seats = [];
        TimeSpan? SpecialExperience = null;
        bool FlightExperienceBool = false;
        string? catering = null;
        seats = General_Seat_Logic.GetSeats(flight, account);

        if (seats is null) { return; }
        if (seats.Count == 0) { return; }
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Would you be interested in a special flight experience where you can take charge of the plane?");
            Console.WriteLine("(1) Yes");
            Console.WriteLine("(2) No");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.D1)
            {
                FlightExperienceBool = true;
                SpecialExperience = FlightExperiencePres.FlightExperience(flight.FlightNumber);
                break;
            }
            if (key == ConsoleKey.D2)
            {
                break;
            }
        }
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Basic: Water + Sandwich");
            Console.WriteLine("Standard: Drink of choice + Meal of choice");
            Console.WriteLine("Premium: All-Inclusive");
            Console.WriteLine("");
            Console.WriteLine("Choose your catering option");
            Console.WriteLine("(1) €  8 Basic");
            Console.WriteLine("(2) € 20 Standard");
            Console.WriteLine("(3) € 60 Premium");
            Console.WriteLine("(4) No Catering");
            ConsoleKey key = Console.ReadKey().Key;
            var cateringTuple = Catering.GetCatering(key);
            if (cateringTuple.Valid)
            {
                catering = cateringTuple.Catering;
                break;
            }
            
        }

        int totalprice = Price.GetTotalPrice(flight, seats, FlightExperienceBool, catering);
        int seatPrices = Price.GetSeatPrices(seats);
        Console.Clear();
        Console.WriteLine($"The costs will be €{totalprice}");
        Console.WriteLine("Tren Tax: €50");
        Console.WriteLine($"Seats: €{seatPrices}");
        Console.WriteLine($"Flight: €{flight.Price}");
        if (FlightExperienceBool is true)
            Console.WriteLine($"Special Experience: €{Price.FlightExperiencePrice(FlightExperienceBool)}");
        if (catering is not null)
            Console.WriteLine($"Catering: €{Price.CateringPrice(catering)}");

        Console.WriteLine("");
        Console.WriteLine("Press any key to continue.");
        Console.WriteLine("Or press 'ESC' to cancel the booking.");
        ConsoleKey keyy = Console.ReadKey().Key;
        if (keyy == ConsoleKey.Escape) { LoggedInPresentation.DisplayMenu(account); }
        Console.Write("> ");
        while (true)
        {
            ConsoleKey key = Console.ReadKey().Key;
            Console.Clear();
            Console.WriteLine("Choose payment option:");
            Console.WriteLine("(1) CreditCard");
            Console.WriteLine("(2) IDeal");
            Console.Write("> ");
            if (key == ConsoleKey.D1)
            {
                if (account.CreditCardInfo is null)
                {
                    Console.Clear();
                    Console.WriteLine("It seems like you don't have a card added to your account, let's add one!");
                    Console.WriteLine("Press any key to continue");
                    Console.Write("> ");
                    Console.ReadKey();
                    Console.Clear();
                    account.CreditCardInfo = InputCreditCardInfo.CreateCreditCard();
                    if (account.CreditCardInfo is null)
                    {
                        continue;
                    }
                    ChangeAccount.ChangingAccount(account);
                }
                Console.Clear();
                Console.WriteLine("Do you want to use this card? (Y/N)");
                DisplayCreditCardInfo.CreditCardInfo(account);
                Console.Write("> ");
                ConsoleKey key1 = Console.ReadKey().Key;

                if (key1 == ConsoleKey.Y)
                {
                    Console.Clear();
                    Console.WriteLine("Okay! We will use this card");
                    Console.WriteLine("Press any key to continue");
                    Console.Write("> ");
                    Console.ReadKey();
                    break;

                }
                if (key1 == ConsoleKey.N)
                {
                    // what now? lol
                    // gets sent to the labour camp
                    Console.Clear();
                    Console.WriteLine("Press any key to continue");
                    Console.Write("> ");
                    Console.ReadKey();
                    continue;
                }

            }
            if (key == ConsoleKey.D2)
            {
                Console.Clear();
                IDeal.Pay();
                Console.WriteLine("You have paid with IDeal");
                Console.WriteLine("Press any key to continue");
                Console.Write("> ");
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

        Booking booking = MakeBookingLogic.MakeBooking(flight, bookingCode, seats, SpecialExperience, totalprice, catering);
        account.BookedFlights.Add(booking);

        Email.SendBookingEmail(account, booking, seats);

        ChangeAccount.ChangingAccount(account);

        Console.WriteLine(@"Thank you so much for booking with Trenlines!
We sent an email with additional information.
Press any key to continue");
        Console.Write("> ");
        Console.ReadKey();
        LoggedInPresentation.DisplayMenu(account);
    }
}
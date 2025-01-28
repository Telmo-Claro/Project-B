class GeneralSeatSelection
{
    public static void AirplaneOverview(Flight flight, List<Seat> SelectedSeats)
    {
        string AirBlane = flight.Aircraft.PlaneOverview;

        string[] SeatsOrStrings = AirBlane.Split(' ');

        foreach (var seatOrString in SeatsOrStrings)
        {
            if (flight.Aircraft.BookedSeats.Any(seat => seat.SeatId == seatOrString))
            {
                // booked seats
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(seatOrString + " ");
            }
            else if (SelectedSeats.Contains(SelectedSeats.FirstOrDefault(seat => seat.SeatId == seatOrString)) && flight.Aircraft.ValidSeats.Contains(seatOrString))
            {
                // active reservation
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(seatOrString + " ");
            }
            else if (!flight.Aircraft.BookedSeats.Any(seat => seat.SeatId == seatOrString) && flight.Aircraft.ValidSeats.Contains(seatOrString))
            {
                // available seats
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(seatOrString + " ");
            }
            else
            {
                // rest of strings
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(seatOrString + " ");
            }
            Console.ResetColor();
        }
        Console.WriteLine(flight.Aircraft.RestOverview);
    }

    public static List<Seat> SeatMenu(Flight flight, Account account, List<Seat> SelectedSeats)
    {
        while (true)
        {
            Console.Clear();

            AirplaneOverview(flight, SelectedSeats);

            Console.WriteLine("\nEnter seat designation (e.g. A1, B2) or type 'continue' to continue:");
            Console.WriteLine("If you type 'continue' without selecting a seat you will return.");
            Console.WriteLine("\nSelected seats:");
            foreach (var seat1 in SelectedSeats)
            {
                Console.WriteLine(seat1);
            }
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input.ToLower() == "continue")
            {
                break;
            }

            if (!General_Seat_Logic.IsValidSeat(input, flight))
            {
                Console.WriteLine("Invalid seat");
                Thread.Sleep(1000);
                continue;
            }

            Seat seat;
            switch (flight.Aircraft.Name)
            {
                case "Airbus 330":
                    seat = Airbus330_Seat_Logic.MakeSeat(input);
                    break;
                case "Boeing 737":
                    seat = Boeing737_Seat_Logic.MakeSeat(input);
                    break;
                case "Boeing 787":
                    seat = Boeing787_Seat_Logic.MakeSeat(input);
                    break;
                default:
                    seat = General_Seat_Logic.MakeSeat(input);
                    break;
            }

            if (General_Seat_Logic.IsBooked(seat, flight))
            {
                Console.WriteLine("This Seat is already booked");
                Thread.Sleep(1000);
                continue;
            }

            if (General_Seat_Logic.IsSelected(seat, SelectedSeats))
            {
                SelectedSeats.Remove(SelectedSeats.FirstOrDefault(x => x == seat));
                Console.WriteLine("Seat has been deselected");
                Thread.Sleep(1000);
                continue;
            }

            Console.WriteLine($"\nThis is a {seat.Type}. \nPrice: ${seat.Price}. \nWould you like to reserve this seat?");
            Console.WriteLine("(1) Yes");
            Console.WriteLine("(2) No");
            Console.Write("> ");
            ConsoleKey bookingResponse = Console.ReadKey().Key;
            Console.WriteLine();
            while (true)
            {
                if (bookingResponse == ConsoleKey.D1)
                {
                    SelectedSeats.Add(seat);
                    Console.WriteLine("\nSeat reserved successfully!");
                    Thread.Sleep(1000);
                    break;
                }
                else if (bookingResponse == ConsoleKey.D2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please enter 1 or 2.");
                    Console.Write("> ");
                    bookingResponse = Console.ReadKey().Key;
                    Console.WriteLine();
                }
            }
        }
        if (SelectedSeats.Count == 0)
        {
            ViewFlightMenu.DisplayMenu(account);
            return null;
        }
        else
        {
            Console.WriteLine("Done reserving.");
            Thread.Sleep(1000);
            Console.Write("> ");
            return SelectedSeats;
        }
    }

    public static List<Seat> SeatMenuAdmin(Flight flight, Account account, List<Seat> SelectedSeats)
    {
        while (true)
        {
            Console.Clear();

            AirplaneOverview(flight, SelectedSeats);

            Console.WriteLine("\nEnter seat designation (e.g. A1, B2) or type 'continue' to continue:");
            Console.WriteLine("If you type 'continue' without selecting a seat you will return.");
            Console.WriteLine("\nSelected seats:");
            foreach (var seat1 in SelectedSeats)
            {
                Console.WriteLine(seat1);
            }
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input.ToLower() == "continue")
            {
                break;
            }

            if (!General_Seat_Logic.IsValidSeat(input, flight))
            {
                Console.WriteLine("Invalid seat");
                Thread.Sleep(1000);
                continue;
            }

            Seat seat;
            switch (flight.Aircraft.Name)
            {
                case "Airbus 330":
                    seat = Airbus330_Seat_Logic.MakeSeat(input);
                    break;
                case "Boeing 737":
                    seat = Boeing737_Seat_Logic.MakeSeat(input);
                    break;
                case "Boeing 787":
                    seat = Boeing787_Seat_Logic.MakeSeat(input);
                    break;
                default:
                    seat = General_Seat_Logic.MakeSeat(input);
                    break;
            }

            if (General_Seat_Logic.IsBooked(seat, flight))
            {
                Console.WriteLine("This Seat is already booked");
                Thread.Sleep(1000);
                continue;
            }

            if (General_Seat_Logic.IsSelected(seat, SelectedSeats))
            {
                SelectedSeats.Remove(SelectedSeats.FirstOrDefault(x => x == seat));
                Console.WriteLine("Seat has been deselected");
                Thread.Sleep(1000);
                continue;
            }

            Console.WriteLine($"\nWould you like to reserve this seat?");
            Console.WriteLine("(1) Yes");
            Console.WriteLine("(2) No");
            Console.Write("> ");
            ConsoleKey bookingResponse = Console.ReadKey().Key;
            Console.WriteLine();
            while (true)
            {
                if (bookingResponse == ConsoleKey.D1)
                {
                    SelectedSeats.Add(seat);
                    Console.WriteLine("\nSeat reserved successfully!");
                    Thread.Sleep(1000);
                    break;
                }
                else if (bookingResponse == ConsoleKey.D2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please enter 1 or 2.");
                    Console.Write("> ");
                    bookingResponse = Console.ReadKey().Key;
                    Console.WriteLine();
                }
            }
        }
        if (SelectedSeats.Count == 0)
        {
            ViewFlightMenu.DisplayMenu(account);
            return null;
        }
        else
        {
            Console.WriteLine("Done reserving.");
            Thread.Sleep(1000);
            Console.Write("> ");
            return SelectedSeats;
        }
    }
}


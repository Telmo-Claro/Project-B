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
    }
    public static List<Seat> SeatMenu(Flight flight)
    {
        List<Seat> SelectedSeats = new List<Seat>();
        while (true)
        {
            Console.Clear();

            AirplaneOverview(flight, SelectedSeats);

            Console.WriteLine("\nEnter seat designation (e.g. A1, B2) or type 'exit' to quit:");
            Console.WriteLine("\nBooked Seats:");
            foreach (var seat1 in SelectedSeats)
            {
                Console.WriteLine(seat1);
            }
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            if (!(General_Seat_Logic.IsValidSeat(input, flight)))
            {
                Console.WriteLine("Invalid seat");
                Thread.Sleep(1000);
                continue;
            }

            if ((General_Seat_Logic.IsBooked(input, flight)))
            {
                Console.WriteLine("This Seat is already booked");
                Thread.Sleep(1000);
                continue;
            }

            if ((General_Seat_Logic.IsSelected(input, SelectedSeats)))
            {
                SelectedSeats.Remove(SelectedSeats.FirstOrDefault(seat => seat.SeatId == input));
                Console.WriteLine("Seat has been deselected");
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
            Console.WriteLine($"This is a {seat.Type}. Price: ${seat.Price}. Would you like to reserve this seat?");
            Console.WriteLine("(1) Yes");
            Console.WriteLine("(2) No");
            Console.WriteLine(">");
            ConsoleKey bookingResponse = Console.ReadKey().Key;
            while (true)
            {
                if (bookingResponse == ConsoleKey.D1)
                {
                    SelectedSeats.Add(seat);
                    Console.WriteLine("Seat reserved successfully!");
                    Thread.Sleep(1000);
                    break;
                }
                if (bookingResponse == ConsoleKey.D2)
                {
                    break;
                }
                else { break; }
            }
        }
        Console.WriteLine("Done reserving.");
        Thread.Sleep(1000);
        return SelectedSeats;
    }
}


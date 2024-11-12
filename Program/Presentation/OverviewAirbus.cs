using System.Runtime.CompilerServices;

public static class OverviewAirbus330
{
    public static List<Seat> Display330(Flight flight)
    {
        List<Seat> bookedSeats = new List<Seat>();
        Console.WriteLine("Airbus 330:");
        Console.WriteLine("First class: Row 1-3 - €250");
        Console.WriteLine("Business class: Row 6-10 - €150");
        Console.WriteLine("Economy class: Row 11-24, 30-42 - €30");

        Console.WriteLine("                ╭────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╮                           ");
        Console.WriteLine("          ╭─────╯  J1 J2 J3 ╭───╮ J6 J7 J8 J9 J10 J11 J12 J13 J14 J15 J16 J17 J18 J19 J20 J21 J22 J23 J24 ╭───╮ J30 J31 J32 J33 J34 J35 J36 J37 J38 J39 J40 J41 J42 J43          ╰─────────────╮             ");
        Console.WriteLine("      ╭───╯  ╭───╮ H1 H2 H3 ╰───╯ H6 H7 H8 H9 H10 H11 H12 H13 H14 H15 H16 H17 H18 H19 H20 H21 H22 H23 H24 ╰───╯ H30 H31 H32 H33 H34 H35 H36 H37 H38 H39 H40 H41 H42                            ╰───╮         ");
        Console.WriteLine("   ╭──╯   │  ╰───╯                                                                                                                                                                                 │         ");
        Console.WriteLine(" ╭─╯      │                                                                                                                                                                    ╭─────────╮         │         ");
        Console.WriteLine("╭╯        │   ╭───╮            ╭───╮ G6 G7 G8 G9 G10 G11 G12 G13 G14 G15 G16 G17 G18 G19 G20 G21 G22 G23 G24 ╭───╮ G30 G31 G32 G33 G34 G35 G36 G37 G38 G39 G40 G41 G42 ╭───╮   ╰─────────╯         │         ");
        Console.WriteLine("│         │   │   │   G1 G2 G3 │   │ F6 F7 F8 F9 F10 F11 F12 F13 F14 F15 F16 F17 F18 F19 F20 F21 F22 F23 F24 │   │ F30 F31 F32 F33 F34 F35 F36 F37 F38 F39 F40 F41 F42 │   │                       │         ");
        Console.WriteLine("│         │   │   │   D1 D2 D3 │   │ E6 E7 E8 E9 E10 E11 E12 E13 E14 E15 E16 E17 E18 E19 E20 E21 E22 E23 E24 │   │ E30 E31 E32 E33 E34 E35 E36 E37 E38 E39 E40 E41 E42 │   │                       │         ");
        Console.WriteLine("╰╮        │   ╰───╯            ╰───╯ D6 D7 D8 D9 D10 D11 D12 D13 D14 D15 D16 D17 D18 D19 D20 D21 D22 D23 D24 ╰───╯ D30 D31 D32 D33 D34 D35 D36 D37 D38 D39 D40 D41 D42 ╰───╯   ╭─────────╮         │         ");
        Console.WriteLine(" ╰─╮      │                                                                                                                                                                    ╰─────────╯         │         ");
        Console.WriteLine("   ╰──╮   │  ╭───╮                                                                                                                                                                                 │         ");
        Console.WriteLine("      ╰───╮  ╰───╯ B1 B2 B3 ╭───╮ B6 B7 B8 B9 B10 B11 B12 B13 B14 B15 B16 B17 B18 B19 B20 B21 B22 B23 B24 ╭───╮ B30 B31 B32 B33 B34 B35 B36 B37 B38 B39 B40 B41 B42     ╭───╮                  ╭───╯          ");
        Console.WriteLine("          ╰─────╮  A1 A2 A3 ╰───╯ A6 A7 A8 A9 A10 A11 A12 A13 A14 A15 A16 A17 A18 A19 A20 A21 A22 A23 A24 ╰───╯ A30 A31 A32 A33 A34 A35 A36 A37 A38 A39 A40 A41 A42     ╰───╯    ╭─────────────╯              ");
        Console.WriteLine("                ╰────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╯                            ");


        while (true)
        {
            Console.WriteLine("\nEnter seat designation (e.g. A1, B2) or type 'exit' to quit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            if (input.Length < 2)
            {
                Console.WriteLine("Invalid seat selection. Please enter a valid seat designation (e.g. A1, B2).");
                continue;
            }

            char seatLetter = char.ToUpper(input[0]);
            if (!((seatLetter == 'A' || seatLetter == 'B' || seatLetter == 'D' || seatLetter == 'G' || seatLetter == 'H' || seatLetter == 'J')))
            {
                Console.WriteLine("Invalid seat selection.");
                continue;
            }

            string seatNumberPart = input.Substring(1); // seat id splitsen -> a1 - 1 en b2 - 2 etc 
            if (!int.TryParse(seatNumberPart, out int seatNumber) || seatNumber < 1 || seatNumber > 43)
            {
                Console.WriteLine("Invalid seat selection.");
                continue;
            }

            if ((seatLetter == 'C' || seatLetter == 'I') ||
                (seatNumber >= 25 && seatNumber <= 29) ||
                (seatNumber == 43 && (seatLetter != 'J' && seatLetter != 'H')))
            {
                Console.WriteLine("Invalid seat selection.");
                continue;
            }

            bool seatIsTaken = bookedSeats.Exists(seat => seat.SeatId.Equals(input, StringComparison.OrdinalIgnoreCase));
            if (seatIsTaken)
            {
                Console.WriteLine("This seat is already taken. Please choose another seat.");
                continue;
            }

            bool isWindowSeat = seatLetter == 'A' || seatLetter == 'J';
            bool isFirstClass = seatNumber >= 1 && seatNumber <= 3;
            bool isBusinessClass = seatNumber >= 6 && seatNumber <= 10;
            bool isEconomyClass = (seatNumber >= 11 && seatNumber <= 24) || (seatNumber >= 30 && seatNumber <= 42);
            bool isExtraLegroom = seatNumber == 6 || seatNumber == 30;

            string seatType;
            double seatPrice = 0;
            string additionalInfo = "";

            if (isWindowSeat && isBusinessClass)
            {
                seatType = "Window seat in Business Class";
                seatPrice = 150;
            }
            else if (isWindowSeat && isFirstClass)
            {
                seatType = "Window seat in First Class";
                seatPrice = 250;
            }
            else if (isFirstClass)
            {
                seatType = "First Class seat";
                seatPrice = 250;
            }
            else if (isWindowSeat && isExtraLegroom)
            {
                seatType = "Window seat with extra legroom";
                seatPrice = 30;
            }
            else if (isWindowSeat)
            {
                seatType = "Window seat in Economy Class";
                seatPrice = 0;
            }
            else if (isBusinessClass)
            {
                seatType = "Business Class seat";
                seatPrice = 150;
            }
            else if (isExtraLegroom)
            {
                seatType = "Extra legroom seat";
                seatPrice = 30;
            }
            else if (isEconomyClass)
            {
                seatType = "Economy Class seat";
                seatPrice = 0;
            }
            else
            {
                seatType = "Seat not available";
                seatPrice = 0;
            }
            // check if the seat is booked
            foreach (var Seat in flight.Aircraft.BookedSeats)
            {
                if (Seat.SeatId == input)
                {
                    Console.WriteLine("This seat is already booked");
                    Console.ReadKey();
                    continue;
                }
            }

            Console.WriteLine($"This is a {seatType}. Price: ${seatPrice}. Would you like to book this seat? (yes/no)");
            string bookingResponse = Console.ReadLine();

            if (bookingResponse.ToLower() == "yes")
            {
                Seat bookedSeat = new Seat(input, seatType);
                bookedSeats.Add(bookedSeat);

                Console.WriteLine("Seat booked successfully!");
            }
            else
            {
                Console.WriteLine("Seat not booked. You can select another seat.");
            }

            Console.WriteLine("\nBooked Seats:");
            foreach (var seat in bookedSeats)
            {
                Console.WriteLine(seat);
            }

            Console.WriteLine("\nWould you like to book another seat? Type 'exit' to quit.");
        }

        Console.WriteLine("Done booking.");
        return bookedSeats;
    }
}
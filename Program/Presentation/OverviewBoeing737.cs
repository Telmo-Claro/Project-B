public static class OverviewBoeing737
{
    public static List<Seat> Display737(Flight flight)
    {
        List<Seat> bookedSeats = new List<Seat>(); // List booked seats later naar json veranderen.
        Console.WriteLine("Boeing 737:"); 
        Console.WriteLine("Business class from row 1-6 - €100");
        Console.WriteLine("Extra leg room row 15-16 - €20");
        Console.WriteLine("Economy from row 7-34 - €0");
        
        Console.WriteLine("                ╭──────────────────────────────────────────────────────────────────────────────────────────────────────────────╮                                              ");
        Console.WriteLine("          ╭─────╯                                                                                                              ╰────────────────────────────────╮             ");
        Console.WriteLine("      ╭───╯             F2 F3 F4 F5 F6 F7 F8 F9 F10 F11 F12 F13 F14 F15 F16 F17 F18 F19 F20 F21 F22 F23 F24 F25 F26 F27 F28 F29 F30 F31 F32 F33     ╭───╮       ╰───╮         ");
        Console.WriteLine("   ╭──╯   │             E2 E3 E4 E5 E6 E7 E8 E9 E10 E11 E12 E13 E14 E15 E16 E17 E18 E19 E20 E21 E22 E23 E24 E25 E26 E27 E28 E29 E30 E31 E32 E33     │   │           │         ");
        Console.WriteLine(" ╭─╯      │             D2 D3 D4 D5 D6 D7 D8 D9 D10 D11 D12 D13 D14 D15 D16 D17 D18 D19 D20 D21 D22 D23 D24 D25 D26 D27 D28 D29 D30 D31 D32 D33     ╰───╯           │         ");
        Console.WriteLine("╭╯        │                                                                                                                                                         │         ");
        Console.WriteLine("│         │                                                                                                                                                         │         ");
        Console.WriteLine("╰╮        │  ╭───╮                                                                                                                                                  │         ");
        Console.WriteLine(" ╰─╮      │  │   │   C1 C2 C3 C4 C5 C6 C7 C8 C9 C10 C11 C12 C13 C14 C15 C16 C17 C18 C19 C20 C21 C22 C23 C24 C25 C26 C27 C28 C29 C30 C31 C32 C33     ╭───╮           │         ");
        Console.WriteLine("   ╰──╮   │  │   │   B1 B2 B3 B4 B5 B6 B7 B8 B9 B10 B11 B12 B13 B14 B15 B16 B17 B18 B19 B20 B21 B22 B23 B24 B25 B26 B27 B28 B29 B30 B31 B32 B33     │   │        ╭──╯         ");
        Console.WriteLine("      ╰───╮  ╰───╯   A1 A2 A3 A4 A5 A6 A7 A8 A9 A10 A11 A12 A13 A14 A15 A16 A17 A18 A19 A20 A21 A22 A23 A24 A25 A26 A27 A28 A29 A30 A31 A32 A33     ╰───╯    ╭───╯            ");
        Console.WriteLine("          ╰─────╮                                                                                                              ╭─────────────────────────────╯                 ");
        Console.WriteLine("                ╰──────────────────────────────────────────────────────────────────────────────────────────────────────────────╯                                               ");
        

        while (true)
        {
            Console.WriteLine("Enter seat designation (e.g. A1, B2) or type 'exit' to quit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit") // Voor nu exit, later bepalen wij wat onze `exit` wordt.
            {
                break;
            }

            
            if (input.Length < 2)
            {
                Console.WriteLine("Invalid seat selection. Please enter a valid seat designation (e.g. A1, B2).");
                continue;
            }

            // input check.
            char seatLetter = char.ToUpper(input[0]);
            if (seatLetter < 'A' || seatLetter > 'F')
            {
                Console.WriteLine("Invalid seat selection.");
                continue;
            }

            // input check.
            string seatNumberPart = input.Substring(1);
            if (!int.TryParse(seatNumberPart, out int seatNumber) || seatNumber < 1 || seatNumber > 33)
            {
                Console.WriteLine("Invalid seat selection.");
                continue;
            }

            // Deze stoelen mag je niet booken.
            if ((input.Equals("F1", StringComparison.OrdinalIgnoreCase)) || 
                (input.Equals("E1", StringComparison.OrdinalIgnoreCase)) || 
                (input.Equals("D1", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Invalid seat selection.");
                continue;
            }


            // dit gaat naar logic layer later in sprint 3/4
            bool isWindowSeat = seatLetter == 'A' || seatLetter == 'F';
            bool isBusinessClass = seatNumber >= 1 && seatNumber <= 6;
            bool isExtraLegroom = (seatLetter == 'A' || seatLetter == 'B' || seatLetter == 'C' || seatLetter == 'D' || seatLetter == 'E' || seatLetter == 'F') && (seatNumber == 15 || seatNumber == 16);

            string seatType;
            double seatPrice = 0;

            if (isWindowSeat && isBusinessClass)
            {
                seatType = "Business Classs";
                seatPrice = 100;
            }
            else if (isWindowSeat && isExtraLegroom)
            {
                seatType = "Extra leg room";
                seatPrice = 20;
            }
            else if (isWindowSeat)
            {
                seatType = "Economy Class";
                seatPrice = 0;
            }
            else if (isBusinessClass)
            {
                seatType = "Business Class";
                seatPrice = 100;
            }
            else if (isExtraLegroom)
            {
                seatType = "Extra legroom seat";
                seatPrice = 20;
            }
            else
            {
                seatType = "Economy";
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
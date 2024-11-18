public static class OverviewBoeing787
{
    public static List<Seat> Display787(Flight flight)
    {
        List<Seat> bookedSeats = new List<Seat>();
        Console.WriteLine("Boeing 787:");
        Console.WriteLine("First class row 1-3 - €200");
        Console.WriteLine("Business class from row 4-6 - €100");
        Console.WriteLine("Extra leg room row 16 and 27 - €20");
        Console.WriteLine("Economy from row 16-38 - €0");
        
        Console.WriteLine("                ╭──────────────────────────┬───┬─────────────────┬───┬────────┬───────────┬─────────────────────────────────────────────────────────────────────────────────────────────┬───────╮");
        Console.WriteLine("          ╭─────╯                          │   │     L1 L2 L3    │   │        ╷ L4 L5 L6  ╷   L16 L17 L18 L19 L20 L21 L22 L23 L24 L25 ╭───╮     L27 L28 L29 L30 L31 L32 L33 L34 L35 L36 │ ╭───╮ ╰───────╮");
        Console.WriteLine("      ╭───╯     │   ╭───╮                  ╰───╯     K1 K2 K3    ╰───╯        ╷ K4 K5 K6  ╷   K16 K17 K18 K19 K20 K21 K22 K23 K24 K25 │   │     K27 K28 K29 K30 K31 K32 K33 K34 K35 K36 │ │   │         ╰─┬");
        Console.WriteLine("   ╭──╯         │   │   │                                                                     J16 J17 J18 J19 J20 J21 J22 J23 J24 J25 ╰───╯     J27 J28 J29 J30 J31 J32 J33 J34 J35 J36 ╵ ╰───╯           │ ");
        Console.WriteLine(" ╭─╯            │   │   │                                     ╭───╮    ╭───╮                                                                                                                              │ ");
        Console.WriteLine("╭╯              │   ╰───╯                           F1 F2 F3  │   │    │   │    F4 F5 F6   ╷  F16 F17 F18 F19 F20 F21 F22 F23 F24 F25 ╷  ╭───╮  F27 F28 F29 F30 F31 F32 F33 F34 F35 F36 F37 F38  ╭───╮    │");
        Console.WriteLine("│               │                                             │   │    │   │               ╷  E16 E17 E18 E19 E20 E21 E22 E23 E24 E25 │  │   │  E27 E28 E29 E30 E31 E32 E33 E34 E35 E36 E37 F38  │   │    │");
        Console.WriteLine("╰╮              │   ╭───╮                           D1 D2 D3  │   │    │   │    D4 D5 D6   ╷  D16 D17 D18 D19 D20 D21 D22 D23 D24 D25 ╵  ╰───╯  D27 D28 D29 D30 D31 D32 D33 D34 D35 D36 D37 F38  ╰───╯    │");
        Console.WriteLine(" ╰─╮            │   │   │                                     ╰───╯    ╰───╯                                                                                                                              │ ");
        Console.WriteLine("   ╰──╮         │   │   │                   ╭───╮                                             C16 C17 C18 C19 C20 C21 C22 C23 C24 C25 ╭───╮     C27 C28 C29 C30 C31 C32 C33 C34 C35 C36 ╷ ╭───╮           │");
        Console.WriteLine("      ╰───╮     │   ╰───╯                   │   │    B1 B2 B3  ╭─────╮        ╷ B4 B5 B6  ╷   B16 B17 B18 B19 B20 B21 B22 B23 B24 B25 │   │     B27 B28 B29 B30 B31 B32 B33 B34 B35 B36 │ │   │          ╭┴");
        Console.WriteLine("          ╰─────╮                           │   │    A1 A2 A3  │     │        ╷ A4 A5 A6  ╷   A16 A17 A18 A19 A20 A21 A22 A23 A24 A25 ╰───╯     A27 A28 A29 A30 A31 A32 A33 A34 A35 A36 │ ╰───╯   ╭──────╯");
        Console.WriteLine("                ╰───────────────────────────┴───┴──────────────┴─────┴────────┴───────────┴─────────────────────────────────────────────────────────────────────────────────────────────┴─────────╯");


        while (true)
        {
            Console.WriteLine("Enter seat designation (e.g. A1, B2) or type 'exit' to quit:");
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
            if (!((seatLetter >= 'A' && seatLetter <= 'D') || (seatLetter >= 'E' && seatLetter <= 'L')))
            {
                Console.WriteLine("Invalid seat selection.");
                continue;
            }

            
            string seatNumberPart = input.Substring(1);
            if (!int.TryParse(seatNumberPart, out int seatNumber) || seatNumber < 1 || seatNumber > 38)
            {
                Console.WriteLine("Invalid seat selection.");
                continue;
            }

            if ((seatLetter == 'C' && seatNumber >= 1 && seatNumber <= 15) ||  
                (seatLetter == 'E' && seatNumber >= 1 && seatNumber <= 15) ||  
                (seatLetter == 'J' && seatNumber >= 1 && seatNumber <= 15) ||  
                seatNumber == 26 ||                                           
                (seatLetter != 'D' && seatLetter != 'E' && seatLetter != 'F' && seatNumber > 36) || 
                (seatLetter == 'F' && seatNumber > 38) ||                      
                (seatLetter == 'D' && seatNumber > 38) ||                      
                (seatLetter == 'E' && seatNumber > 38))                        
            {
                Console.WriteLine("Invalid seat selection.");
                continue;
            }

            if (flight.Aircraft.BookedSeats.Any(seat => seat.SeatId == input))
            {
                Console.WriteLine("This seat is already booked");
                Console.ReadKey();
                continue;
            }

            bool isWindowSeat = seatLetter == 'A' || seatLetter == 'L';  
            bool isFirstClass = seatNumber >= 1 && seatNumber <= 3;
            bool isBusinessClass = seatNumber >= 4 && seatNumber <= 6;
            bool isEconomyClass = seatNumber >= 16 && seatNumber <= 38;  
            bool isExtraLegroom = 
                (seatNumber == 16 || seatNumber == 27) && 
                (seatLetter == 'A' || seatLetter == 'B' || seatLetter == 'C' || seatLetter == 'D' || 
                 seatLetter == 'E' || seatLetter == 'F' || seatLetter == 'J' || seatLetter == 'K' || seatLetter == 'L');

            string seatType;
            int seatPrice = 0;
            
            if (isWindowSeat && isBusinessClass)
            {
                seatType = "Business Class";
                seatPrice = 100;
            }
            else if (isFirstClass && isWindowSeat)
            {
                seatType = "First Class";
                seatPrice = 200;
            }
            else if (isFirstClass)
            {
                seatType = "First Class";
                seatPrice = 200;
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
                seatType = "Extra leg room";
                seatPrice = 20;
            }
            else if (isEconomyClass)
            {
                seatType = "Economy Class";
                seatPrice = 0;  
            }
            else
            {
                seatType = "Report to Devs";
                seatPrice = 0;
            }

            Console.WriteLine($"This is a {seatType}. Price: ${seatPrice}. Would you like to book this seat? (yes/no)");
            string bookingResponse = Console.ReadLine();

            if (bookingResponse.ToLower() == "yes")
            {
                Seat bookedSeat = new Seat(input, seatType, seatPrice);
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
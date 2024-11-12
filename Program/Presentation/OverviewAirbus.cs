public static class OverviewAirbus330
{
    public class Seat
    {
        public string SeatId { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public bool IsTaken { get; set; }
        public string AdditionalInfo { get; set; }

        public Seat(string seatId, string type, double price, bool isTaken, string additionalInfo)
        {
            SeatId = seatId;
            Type = type;
            Price = price;
            IsTaken = isTaken;
            AdditionalInfo = additionalInfo;
        }

        public override string ToString()
        {
            return $"{SeatId} - {Type} - ${Price} - {(IsTaken ? "Taken" : "Available")} - {AdditionalInfo}";
        }
    }

    public static void Display330()
    {
        List<Seat> bookedSeats = new List<Seat>();
        Console.WriteLine("Airbus 330:");
        Console.WriteLine("First class: Row 1-3");
        Console.WriteLine("Business class: Row 6-10");
        Console.WriteLine("Economy class: Row 11-24, 30-42");
        
        Console.WriteLine("\u2708\ufe0e");
        
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

            Console.WriteLine($"This is a {seatType}. Price: ${seatPrice}. Would you like to book this seat? (yes/no)");
            string bookingResponse = Console.ReadLine();

            if (bookingResponse.ToLower() == "yes")
            {
                Seat bookedSeat = new Seat(input, seatType, seatPrice, true, additionalInfo);
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
    }
}

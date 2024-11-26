class Boeing787_Seat_Logic : General_Seat_Logic
{
    public static new Seat MakeSeat(string seat)
    {
        int seatNumber = Int32.Parse(seat.Substring(1));
        char seatLetter = char.ToUpper(seat[0]);

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

        return new Seat(seat, seatType, seatPrice);
    }
}


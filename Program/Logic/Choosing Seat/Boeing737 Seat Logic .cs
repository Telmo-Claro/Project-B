class Boeing737_Seat_Logic : General_Seat_Logic
{
    public static new Seat MakeSeat(string seat)
    {
        int seatNumber = Int32.Parse(seat.Substring(1));
        char seatLetter = char.ToUpper(seat[0]);

        bool isWindowSeat = seatLetter == 'A' || seatLetter == 'F';
        bool isBusinessClass = seatNumber >= 1 && seatNumber <= 6;
        bool isExtraLegroom = (seatLetter == 'A' || seatLetter == 'B' || seatLetter == 'C' || seatLetter == 'D' || seatLetter == 'E' || seatLetter == 'F') && (seatNumber == 15 || seatNumber == 16);

        string seatType;
        int seatPrice = 0;

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

        return new Seat(seat, seatType, seatPrice);
    }
}


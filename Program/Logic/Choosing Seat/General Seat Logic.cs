class General_Seat_Logic
{
    public static List<Seat> GetSeats(Flight flight, Account account)
    {

        return GeneralSeatSelection.SeatMenu(flight, account);
    }

    public static bool IsValidSeat(string seatNumber, Flight flight)
    {
        if (flight.Aircraft.ValidSeats.Contains(seatNumber))
        { return true; }
        return false;
    }

    public static bool IsBooked(string seatCheck, Flight flight)
    {
        if (flight.Aircraft.BookedSeats.Any(seat => seat.SeatId == seatCheck))
        {
            return true;
        }
        return false;
    }
    public static bool IsSelected(string seatCheck, List<Seat> SelectedSeats)
    {
        if (SelectedSeats.Contains(SelectedSeats.FirstOrDefault(seat => seat.SeatId == seatCheck)))
        {
            return true;
        }
        return false;
    }

    public static Seat MakeSeat(string seat)
    {
        int seatNumber = Int32.Parse(seat.Substring(1));
        char seatLetter = char.ToUpper(seat[0]);

        bool isWindowSeat = seatLetter == 'A' || seatLetter == 'J';
        bool isFirstClass = seatNumber >= 1 && seatNumber <= 3;
        bool isBusinessClass = seatNumber >= 6 && seatNumber <= 10;
        bool isEconomyClass = (seatNumber >= 11 && seatNumber <= 24) || (seatNumber >= 30 && seatNumber <= 42);
        bool isExtraLegroom = seatNumber == 6 || seatNumber == 30;

        string seatType;
        int seatPrice = 0;
        string additionalInfo = "";

        if (isWindowSeat && isBusinessClass)
        {
            seatType = "Business Class";
            seatPrice = 150;
        }
        else if (isWindowSeat && isFirstClass)
        {
            seatType = "First Class";
            seatPrice = 250;
        }
        else if (isFirstClass)
        {
            seatType = "First Class";
            seatPrice = 250;
        }
        else if (isWindowSeat && isExtraLegroom)
        {
            seatType = "Extra leg room";
            seatPrice = 30;
        }
        else if (isWindowSeat)
        {
            seatType = "Economy Class";
            seatPrice = 0;
        }
        else if (isBusinessClass)
        {
            seatType = "Business Class";
            seatPrice = 150;
        }
        else if (isExtraLegroom)
        {
            seatType = "Extra leg room";
            seatPrice = 30;
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


public static class MainBookingPresentation
{
    public static void DisplayMenu(Account account)
    {
        Console.Clear();
        Console.WriteLine("---------------- TRENLINES -----------------");
        Console.WriteLine($"Hello {account.FirstName} {account.LastName}!");
        Console.WriteLine($"(1) View booking details of active bookings");
        Console.WriteLine($"(2) View booking details of past flights");
        Console.WriteLine($"(3) Cancel booking");
        Console.WriteLine($"(ESC) Go back");
        Console.WriteLine("---------------- TRENLINES -----------------\n");
        Console.Write("> ");
        var input = Console.ReadKey().Key;
        ManageBookingsLogic.ManageBooking(account, input);

    }
}
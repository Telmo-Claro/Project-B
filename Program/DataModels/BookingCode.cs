public class BookingCode
{
    private static Random random = new Random();
    private static List<string> BookingCodes = [];

    public static string GenerateCode()
    {
        string newCode;
        do
        {
            newCode = random.Next(100000, 1000000).ToString(); // Makes a 6 digit number as a string
        } 
        while (BookingCodes.Contains(newCode)); // Checks if code exists

        return newCode;
    }
}
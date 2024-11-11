public class CodeGenerator
{
    private static Random random = new Random();
    private new List<string> BookingCodes = [];

    public static string GenerateCode(List<string> bookingCodes)
    {
        string newCode;
        do
        {
            newCode = random.Next(100000, 1000000).ToString(); // Makes a 6 digit number as a string
        } 
        while (bookingCodes.Contains(newCode)); // Checks if code exists

        return newCode;
    }
}
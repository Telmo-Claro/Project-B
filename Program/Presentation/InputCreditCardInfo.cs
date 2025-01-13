using System.Globalization;

public class InputCreditCardInfo
{
    public static CreditCard CreateCreditCard()
    {
        string fname;
        do
        {
            Console.WriteLine();
            Console.Write("Enter card First Name: ");
            fname = Console.ReadLine() ?? string.Empty; // Default to empty string if null
        } while (!fname.All(char.IsLetter));

        string lname;
        do
        {
            Console.Write("Enter card Last Name: ");
            lname = Console.ReadLine() ?? string.Empty; // Default to empty string if null
        } while (!lname.All(char.IsLetter));

        string number;
        do
        {
            Console.Write("Enter card number (16 digits): ");
            number = Console.ReadLine() ?? string.Empty; // Default to empty string if null
            if (number.Length != 16 || !number.All(char.IsDigit))
            {
                Console.WriteLine("Invalid card number. Please enter a 16-digit number.");
            }
        } while (number.Length != 16 || !number.All(char.IsDigit));

        string date;
        do
        {
            Console.Write("Enter card Expiration Date (mm/yy): ");
            date = Console.ReadLine() ?? string.Empty;
            bool isParsingSuccessful = false;

            while (!isParsingSuccessful)
            {
                try
                {
                    CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.LCID);
                    ci.Calendar.TwoDigitYearMax = 2099; // Setting end year to 2099
                    DateTime result = DateTime.ParseExact(date, "MM/yy", ci);
                    if (result <= DateTime.Now)
                    {
                        Console.WriteLine("Your credit card is expired and therefore can not be used.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();

                        isParsingSuccessful = false;
                        return null;
                    }
                    isParsingSuccessful = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Please enter a valid date in the format MM/yy.");

                    date = Console.ReadLine();
                }
            }

        } while (string.IsNullOrEmpty(date));

        string cvc;
        do
        {
            Console.Write("Enter card Card CVC Number (3 digits): ");
            cvc = Console.ReadLine() ?? string.Empty; // Default to empty string if null
            if (cvc.Length != 3 || !cvc.All(char.IsDigit))
            {
                Console.WriteLine("Invalid CVC. Please enter a 3-digit number.");
            }
        } while (cvc.Length != 3 || !cvc.All(char.IsDigit));

        return ClassFactory.CreateCreditCard(fname, lname, number, date, cvc);
    }
}
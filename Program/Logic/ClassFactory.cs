public class ClassFactory
{
    public static CreditCard? CreateCreditCard()
    {
        string? fname;
        do
        {
            Console.WriteLine();
            Console.Write("Enter card First Name: ");
            fname = Console.ReadLine();
        } while (fname == null || !fname.All(char.IsLetter));

        string? lname;
        do
        {
            Console.Write("Enter card Last Name: ");
            lname = Console.ReadLine();
        } while (lname == null || !lname.All(char.IsLetter));

        string? number;
        do
        {
            Console.Write("Enter card number (16 digits): ");
            number = Console.ReadLine();
            if (number == null || number.Length != 16 || !number.All(char.IsDigit))
            {
                Console.WriteLine("Invalid card number. Please enter a 16-digit number.");
            }
        } while (number == null || number.Length != 16 || !number.All(char.IsDigit));

        string? date;
        do
        {
            Console.Write("Enter card Expiration Date (mm/yy): ");
            date = Console.ReadLine();
        } while (date == null);

        string? cvc;
        do
        {
            Console.Write("Enter card Card CVC Number (3 digits): ");
            cvc = Console.ReadLine();
            if (cvc == null || cvc.Length != 3 || !cvc.All(char.IsDigit))
            {
                Console.WriteLine("Invalid CVC. Please enter a 3-digit number.");
            }

        } while (cvc == null || cvc.Length != 3 || !cvc.All(char.IsDigit));

        CreditCard credit = new CreditCard(fname, lname, number, date, cvc);
        return credit;
    }

    public static Account CreateAccount(string? firstName, string? lastName,
        string? email, string? phoneNumber, string? password)
    {
        Account account = new Account(firstName, lastName, email, phoneNumber, password);
        return account;
    }

    public static Account CreateAccount(string? firstName, string? lastName,
        string? email, string? phoneNumber, string? password, Payment creditCard)
    {
        Account account = new Account(firstName, lastName, email, phoneNumber, password, creditCard);
        return account;
    }
}
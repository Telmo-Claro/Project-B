public class ClassFactory
{
    public static Payment? CreatePayment(string type)
    {
        switch (type)
        {
            case "IDeal":
                return new IDeal();
            case "CreditCard":
                Console.Write("Enter card First Name: ");
                string? fname = Console.ReadLine();
                Console.Write("Enter card Last Name: ");
                string? lname = Console.ReadLine();
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
                Console.Write("Enter card Expiration Date: ");
                string? date = Console.ReadLine();
                Console.Write("Enter card Card CVC Number: ");
                string? cvc = Console.ReadLine();
                CreditCard credit = new CreditCard(fname, lname, number, date, cvc);
                return credit;
            default:
                return null;
        }
    }

    public static Account? CreateAccount(string? firstName, string? lastName,
        string? email, string? phoneNumber, string? password, Payment paymentMethod)
    {
        Account account = new Account(firstName, lastName, email, phoneNumber, password, paymentMethod);
        return account;
    }
}
public static class CreateAccountPresentation
{
    public static void DisplayMenu()
    {
        while (true)
        {
            string firstName = "";
            string lastName = "";
            string email = "";
            string password = "";
            string phoneNumber = "";
            CreditCard? creditCard = null;
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("TRENLINES - CREATE ACCOUNT");
            Console.WriteLine("--------------------------");
            while (firstName == "")
            {
                Console.Write("First name: ");
                firstName = Console.ReadLine();
            }
            while (lastName == "")
            {
                Console.Write("Last name: ");
                lastName = Console.ReadLine();
            }
            while (email == "" && email.Contains("@") == false)
            {
                Console.Write("Enter email: ");
                email = Console.ReadLine();
            }
            while (phoneNumber == "")
            {
                Console.Write("Phone number: ");
                phoneNumber = Console.ReadLine();
            }
            while (password == "")
            {
                Console.Write("Enter password: ");
                password = PasswordTyper.PasswordReadLine();
            }

            Console.Write("Do you want to add a CreditCard? Y/N: ");
            ConsoleKey input;
            while (true)
            {
                input = Console.ReadKey().Key;
                Console.WriteLine();
                if (input == ConsoleKey.Y || input == ConsoleKey.N)
                {
                    break;
                }
            }

            if (input == ConsoleKey.Y)
            {
                Console.Clear();
                creditCard = InputCreditCardInfo.CreateCreditCard();
                if (creditCard is null)
                {
                    continue;
                }
            }

            if (firstName != null && lastName != null
                                  && email != null && phoneNumber != null
                                  && password != null)
            {
                // firstName, lastName, email, phoneNumber, password
                Account account = ClassFactory.CreateAccount(firstName, lastName, email, phoneNumber, password, creditCard);
                if (input == ConsoleKey.Y)
                {
                    account.CreditCardInfo = creditCard;
                }
                AddAccountLogic.AddAccount(account);
                LoggedInPresentation.DisplayMenu(account);
            }
            break;
        }
    }
}
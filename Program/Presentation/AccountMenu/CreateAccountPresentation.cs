public static class CreateAccountPresentation
{
    public static void TrenLines()
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.WriteLine("TRENLINES - CREATE ACCOUNT");
        Console.WriteLine("--------------------------");
    }
    public static void DisplayMenu()
    {
        while (true)
        {
            string? firstName = null;
            string? lastName = null;
            string? email = null;
            string? password = null;
            string? phoneNumber = null;
            CreditCard? creditCard = null;
            TrenLines();
            
            while(!ValidateAccountInformation.ValidateFirstName(firstName))
            {
                TrenLines();
                Console.Write("First name: ");
                firstName = Console.ReadLine();
                if (!ValidateAccountInformation.ValidateFirstName(firstName))
                {
                    Thread.Sleep(800);
                    Console.WriteLine("Please enter a valid first name.");
                    Thread.Sleep(800);
                    Console.WriteLine("No special characters or numbers.");
                    Thread.Sleep(2000);
                }
            }
            
            while (!ValidateAccountInformation.ValidateLastName(lastName))
            {
                TrenLines();
                Console.Write("Last name: ");
                lastName = Console.ReadLine();
                if (!ValidateAccountInformation.ValidateLastName(lastName))
                {
                    Thread.Sleep(800);
                    Console.WriteLine("Please enter a valid last name.");
                    Thread.Sleep(800);
                    Console.WriteLine("No special characters or numbers.");
                    Thread.Sleep(2000);
                }
            }
            while (!ValidateAccountInformation.ValidateEmail(email))
            {
                TrenLines();
                Console.Write("Enter email: ");
                email = Console.ReadLine();
                if (!ValidateAccountInformation.ValidateEmail(email))
                {
                    Thread.Sleep(800);
                    Console.WriteLine("Please enter a valid email.");
                    Thread.Sleep(800);
                    Console.WriteLine("A valid email includes one '@' character.");
                    Thread.Sleep(2000);
                }
            }
            while (!ValidateAccountInformation.ValidatePhoneNumber(phoneNumber))
            {
                TrenLines();
                Console.Write("Phone number: ");
                phoneNumber = Console.ReadLine();
                if(!ValidateAccountInformation.ValidatePhoneNumber(phoneNumber))
                {
                    Thread.Sleep(800);
                    Console.WriteLine("Please enter a valid phone number.");
                    Thread.Sleep(800);
                    Console.WriteLine("A valid phone number includes only numbers.");
                    Thread.Sleep(800);
                    Console.WriteLine("It also has to be between 9 and 12 digits.");
                    Thread.Sleep(2000);
                }
            }
            while (!ValidateAccountInformation.ValidatePassword(password))
            {
                TrenLines();
                Console.Write("Enter password: ");
                password = PasswordTyper.PasswordReadLine();
                if (!ValidateAccountInformation.ValidatePassword(password))
                {
                    Thread.Sleep(800);
                    Console.WriteLine("Please enter a valid password.");
                    Thread.Sleep(800);
                    Console.WriteLine("A password has to have more than 6 characters.");
                    Thread.Sleep(2000);
                }
            }
            
            Console.Write("Do you want to add a CreditCard? Y/N: ");
            ConsoleKey input;
            while (true)
            {
                input = Console.ReadKey().Key;
                Console.WriteLine();
                if (input is ConsoleKey.Y or ConsoleKey.N)
                {
                    break;
                }
            }

            if (input == ConsoleKey.Y)
            {
                Console.Clear();
                creditCard = InputCreditCardInfo.CreateCreditCard();
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
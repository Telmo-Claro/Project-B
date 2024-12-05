public static class ChangeAccountDataPresentation
{
    public static void DisplayMenu(Account account)
    {
        DisplayAccountInfo.AccountInfo(account);
        DisplayCreditCardInfo.CreditCardInfo(account);
        Console.WriteLine("(1) Change name");
        Console.WriteLine("(2) Change email");
        Console.WriteLine("(3) Change phone number");
        Console.WriteLine("(4) Change password");
        Console.WriteLine("(5) Change CreditCard information");
        Console.WriteLine("(ESC) Go back");
        Console.Write("> ");

        var choice = Console.ReadKey().Key;
        // ChangeAccountDataLogic.ChangeData(account, choice);

        switch (choice)
        {
            case ConsoleKey.D1:
                ChangeName(account);
                break;
            case ConsoleKey.D2:
                ChangeEmail(account);
                break;
            case ConsoleKey.D3:
                ChangePhoneNumber(account);
                break;
            case ConsoleKey.D4:
                ChangePassword(account);
                break;
            case ConsoleKey.D5:
                ChangeCreditCardInformation(account);
                break;
            case ConsoleKey.Escape:
            case ConsoleKey.Tab:
                LoggedInPresentation.DisplayMenu(account);
                break;
            default:
                Console.WriteLine();
                Console.WriteLine("Please enter a valid choice!");
                Thread.Sleep(2000);
                break;
        }
    }

    // Everything from here still to be implemented
    private static void ChangeName(Account account)
    {
        string firstName = string.Empty;
        string lastName = string.Empty;
        while(!ValidateAccountInformation.ValidateFirstName(firstName))
        {
            Console.WriteLine("\nNew first name: ");
            Console.Write("> ");
            firstName = Console.ReadLine();
            if (!ValidateAccountInformation.ValidateFirstName(firstName))
            {
                Thread.Sleep(800);
                Console.WriteLine("Please enter a valid first name.");
                Thread.Sleep(800);
                Console.WriteLine("No special characters or numbers.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        while (!ValidateAccountInformation.ValidateLastName(lastName))
        {
            Console.WriteLine("\nNew last name: ");
            Console.Write("> ");
            lastName = Console.ReadLine();
            if (!ValidateAccountInformation.ValidateLastName(lastName))
            {
                Thread.Sleep(800);
                Console.WriteLine("Please enter a valid last name.");
                Thread.Sleep(800);
                Console.WriteLine("No special characters or numbers.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        
        var newAccount = ChangeAccountDataLogic.ChangeName(account, firstName, lastName);
        if (newAccount != null)
        {
            DisplayMenu(newAccount);
        }
        DisplayMenu(account);
    }
    
    private static void ChangeEmail(Account account)
    {
        string email = string.Empty;
        while (!ValidateAccountInformation.ValidateEmail(email))
        {
            Console.WriteLine("\nEnter new email: ");
            Console.Write("> ");
            email = Console.ReadLine();
            if (!ValidateAccountInformation.ValidateEmail(email))
            {
                Thread.Sleep(800);
                Console.WriteLine("Please enter a valid email.");
                Thread.Sleep(800);
                Console.WriteLine("A valid email includes one '@' character.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        var newAccount = ChangeAccountDataLogic.ChangeEmail(account, email);
        if (newAccount != null)
        {
            DisplayMenu(newAccount);
        }
        DisplayMenu(account);
    }
    
    private static void ChangePhoneNumber(Account account)
    {
        string phoneNumber = string.Empty;
        while (!ValidateAccountInformation.ValidatePhoneNumber(phoneNumber))
        {
            Console.WriteLine("\nNew phone number: ");
            Console.Write("> ");
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
                Console.Clear();
            }
        }
        var newAccount = ChangeAccountDataLogic.ChangePhoneNumber(account, phoneNumber);
        if (newAccount != null)
        {
            DisplayMenu(newAccount);
        }
        DisplayMenu(account);

    }
    
    private static void ChangePassword(Account account)
    {
        string password = string.Empty;
        while (!ValidateAccountInformation.ValidatePassword(password))
        {
            Console.WriteLine("\nEnter new password: ");
            Console.Write("> ");
            password = PasswordTyper.PasswordReadLine();
            if (!ValidateAccountInformation.ValidatePassword(password))
            {
                Thread.Sleep(800);
                Console.WriteLine("Please enter a valid password.");
                Thread.Sleep(800);
                Console.WriteLine("A password has to have more than 6 characters.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        
        var newAccount = ChangeAccountDataLogic.ChangePassword(account, password);
        if (newAccount != null)
        {
            DisplayMenu(newAccount);
        }
        DisplayMenu(account);

    }
    
    private static void ChangeCreditCardInformation(Account account)
    {
        Account? newAccount = null;
        while (true)
        {
            ConsoleKey input;
            Console.Clear();
            Console.WriteLine("Are you sure you want to change your card information? [Y/N] ");
            Console.Write("> ");
            input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.Y:
                    var newCreditCard = InputCreditCardInfo.CreateCreditCard();
                    newAccount = ChangeAccountDataLogic.ChangeCreditCard(account, newCreditCard);
                    break;
                case ConsoleKey.N:
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    input = Console.ReadKey().Key;
                    break;
            }

            if (input != null)
            {
                if (newAccount != null)
                {
                    DisplayMenu(newAccount);
                }
                DisplayMenu(account);
            }
        }
        // ReSharper disable once FunctionNeverReturns
    }
}
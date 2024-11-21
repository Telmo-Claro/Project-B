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
        ChangeAccountDataLogic.ChangeData(account, choice);

        // switch (choice)
        // {
        //     case ConsoleKey.D1:
        //         ChangeName(account);
        //         break;
        //     case ConsoleKey.D2:
        //         ChangeEmail(account);
        //         break;
        //     case ConsoleKey.D3:
        //         ChangePhoneNumber(account);
        //         break;
        // }
    }

    // Everything from here still to be implemented
    // private static void ChangeName(Account account)
    // {
    //     string firstName = string.Empty;
    //     string lastName = string.Empty;
    //     while (true)
    //     {
    //         Console.Write("\nEnter new first name: ");
    //         firstName = Console.ReadLine();
    //         if (string.IsNullOrEmpty(firstName))
    //         {
    //             Console.Write("Please enter a valid first name. Try again: ");
    //             firstName = Console.ReadLine();
    //         }
    //         else
    //         {
    //             break;
    //         }
    //     }
    //     while (true)
    //     {
    //         Console.Write("\nEnter new first name: ");
    //         lastName = Console.ReadLine();
    //         if (string.IsNullOrEmpty(firstName))
    //         {
    //             Console.Write("Please enter a valid first name. Try again: ");
    //             lastName = Console.ReadLine();
    //         }
    //         else
    //         {
    //             break;
    //         }
    //     }
    //     ChangeAccountDataLogic.ChangeName(account, firstName, lastName);
    // }
    //
    // private static void ChangeEmail(Account account)
    // {
    //     string email = string.Empty;
    //     while (true)
    //     {
    //         Console.Write("\nEnter new email: ");
    //         email = Console.ReadLine();
    //         if (string.IsNullOrEmpty(email) || email.Contains("@"))
    //         {
    //             Console.Write("Please enter a valid email. Try again: ");
    //             email = Console.ReadLine();
    //         }
    //         else
    //         {
    //             break;
    //         }
    //     }
    //     ChangeAccountDataLogic.ChangeEmail(account, email);
    // }
    //
    // private static void ChangePhoneNumber(Account account)
    // {
    //     string phoneNumber = string.Empty;
    //     while (true)
    //     {
    //         Console.Write("\nEnter phone number: ");
    //         phoneNumber = Console.ReadLine();
    //         if (string.IsNullOrEmpty(phoneNumber))
    //         {
    //             Console.Write("Please enter a valid email. Try again: ");
    //             phoneNumber = Console.ReadLine();
    //         }
    //         else
    //         {
    //             break;
    //         }
    //     }
    //     ChangeAccountDataLogic.ChangePhoneNumber(account, phoneNumber);
    // }
    //
    // private static void ChagePassword(Account account)
    // {
    //     string password = string.Empty;
    //     while (true)
    //     {
    //         Console.Write("\nEnter phone number: ");
    //         password = Console.ReadLine();
    //         if (string.IsNullOrEmpty(password))
    //         {
    //             Console.Write("Please enter a valid email. Try again: ");
    //             password = Console.ReadLine();
    //         }
    //         else
    //         {
    //             break;
    //         }
    //     }
    //     ChangeAccountDataLogic.ChangePassword(account, password);
    // }
    //
    // private static void ChangeCreditCardInformation(Account account)
    // {
    //     while (true)
    //     {
    //         ConsoleKey input;
    //         do
    //         {
    //             Console.Clear();
    //             Console.WriteLine("Are you sure you want to change your card information? [Y/N] ");
    //             Console.Write("> ");
    //             input = Console.ReadKey().Key;
    //         } while (input != ConsoleKey.Y || input != ConsoleKey.N);
    //         
    //         switch (input)
    //         {
    //             case ConsoleKey.Y:
    //                 var newCreditCard = InputCreditCardInfo.CreateCreditCard();
    //                 ChangeAccountDataLogic.ChangeCreditCard(account, newCreditCard);
    //                 break;
    //             case ConsoleKey.N:
    //                 break;
    //             default:
    //                 Console.WriteLine("Invalid input. Try again.");
    //                 input = Console.ReadKey().Key;
    //                 break;
    //         }
    //     }
    // }
}
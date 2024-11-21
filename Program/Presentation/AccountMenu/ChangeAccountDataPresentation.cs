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
        
        string choice;
        do
        {
            choice = Console.ReadKey().KeyChar.ToString();
        } while (choice == "");
        ChangeAccountDataLogic.ChangeData(account, choice);
    }
}
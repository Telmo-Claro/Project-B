public static class ChangeAccountDataLogic
{
    public static void ChangeData(Account account, string choice)
    {
        var accounts = AccountDataRW.ReadFromJson();
        if (accounts is null) return;
        
        // Check if account exists
        foreach (var x in accounts)
        {
            if (
                x.Email.Equals(account.Email,
                    StringComparison.OrdinalIgnoreCase) &&
                x.Password.Equals(account.Password,
                    StringComparison.OrdinalIgnoreCase) &&
                x.FirstName.Equals(account.FirstName,
                    StringComparison.OrdinalIgnoreCase) &&
                x.LastName.Equals(account.LastName,
                    StringComparison.OrdinalIgnoreCase)
            )
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new first name: ");
                        x.FirstName = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter new last name: ");
                        x.LastName = Console.ReadLine();
                        Console.WriteLine("Name changed successfully!");
                        AccountDataRW.WriteToJson(accounts);
                        ChangeAccountDataPresentation.DisplayMenu(account);
                        break;
                    case "2":
                        Console.Write("Enter new email: ");
                        x.Email = Console.ReadLine();
                        Console.WriteLine("Email changed successfully!");
                        AccountDataRW.WriteToJson(accounts);
                        ChangeAccountDataPresentation.DisplayMenu(account);
                        break;
                    case "3":
                        Console.Write("Enter new phone number: ");
                        x.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Phone number changed successfully");
                        AccountDataRW.WriteToJson(accounts);
                        ChangeAccountDataPresentation.DisplayMenu(account);
                        break;
                    case "4":
                        Console.Write("Enter new password: ");
                        x.Password = Console.ReadLine();
                        Console.WriteLine("Password changed successfully!");
                        AccountDataRW.WriteToJson(accounts);
                        ChangeAccountDataPresentation.DisplayMenu(account);
                        break;
                    case "5":
                        DisplayCreditCardInfo.CreditCardInfo(x);
                        Console.Write("Do you wish to change your information? y/n: ");
                        bool boolChoice = Console.ReadKey().KeyChar.ToString().ToUpper() == "Y" ? true : false;
                        if (boolChoice)
                        {
                            x.CreditCardInfo = InputCreditCardInfo.CreateCreditCard();
                            Console.WriteLine("Payment method changed successfully!");
                        }
                        AccountDataRW.WriteToJson(accounts);
                        ChangeAccountDataPresentation.DisplayMenu(account);
                        break;
                    case "6":
                        AccountDataRW.WriteToJson(accounts);
                        LoggedInPresentation.DisplayMenu(account);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            }
        }
        AccountDataRW.WriteToJson(accounts);
    }
}
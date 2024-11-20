public static class Change_account_data_logic
{
    public static void ChangeData(Account account, int choice)
    {
        var accounts = AccountDataRW.ReadFromJson();
        if (accounts is null) return;
        
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
                    case 1:
                        Console.Write("Enter new first name: ");
                        x.FirstName = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter new last name: ");
                        x.LastName = Console.ReadLine();
                        Console.WriteLine("Name changed successfully!");
                        break;
                    case 2:
                        Console.Write("Enter new email: ");
                        x.Email = Console.ReadLine();
                        Console.WriteLine("Email changed successfully!");
                        break;
                    case 3:
                        Console.Write("Enter new phone number: ");
                        x.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Phone number changed successfully");
                        break;
                    case 4:
                        Console.Write("Enter new password: ");
                        x.Password = Console.ReadLine();
                        Console.WriteLine("Password changed successfully!");
                        break;
                    case 5:
                        DisplayCreditCardInfo.CreditCardInfo(x);
                        Console.Write("Do you wish to change your information? y/n: ");
                        bool boolChoice = Console.ReadKey().KeyChar.ToString().ToUpper() == "Y" ? true : false;
                        if (boolChoice)
                        {
                            x.CreditCardInfo = InputCreditCardInfo.CreateCreditCard();
                            Console.WriteLine("Payment method changed successfully!");
                        }
                        break;
                    case 6:
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
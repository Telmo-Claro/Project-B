using System.Net.Http.Headers;

public static class ChangeAccountDataLogic
{
    public static void ChangeData(Account account, ConsoleKey choice)
    {
        var accounts = AccountDataRW.ReadFromJson();
        if (accounts is null) return;
        // Check if account exists
        foreach (var x in accounts)
        {
            if (x.Email == account.Email && x.Password == account.Password)
                    switch (choice)
                    {
                        case ConsoleKey.D1:
                            Console.Write("\nEnter new first name: ");
                            x.FirstName = Console.ReadLine();
                            Console.Write("\nEnter new last name: ");
                            x.LastName = Console.ReadLine();
                            Console.WriteLine("\nName changed successfully!");
                            AccountDataRW.WriteToJson(accounts);
                            ChangeAccountDataPresentation.DisplayMenu(x);
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine();
                            Console.Write("Enter new email: ");
                            x.Email = Console.ReadLine();
                            Console.WriteLine("Email changed successfully!");
                            AccountDataRW.WriteToJson(accounts);
                            ChangeAccountDataPresentation.DisplayMenu(x);
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine();
                            Console.Write("Enter new phone number: ");
                            x.PhoneNumber = Console.ReadLine();
                            Console.WriteLine("Phone number changed successfully");
                            AccountDataRW.WriteToJson(accounts);
                            ChangeAccountDataPresentation.DisplayMenu(x);
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine();
                            Console.Write("Enter new password: ");
                            x.Password = Console.ReadLine();
                            Console.WriteLine("Password changed successfully!");
                            AccountDataRW.WriteToJson(accounts);
                            ChangeAccountDataPresentation.DisplayMenu(x);
                            break;
                        case ConsoleKey.D5:
                            Console.WriteLine();
                            Console.WriteLine("Are you sure you want to change your CreditCard? [Y/N]");
                            Console.Write("> ");
                    
                            ConsoleKey input;
                            while (true)
                            {
                                input = Console.ReadKey().Key;
                                if (input == ConsoleKey.Y || input == ConsoleKey.N)
                                {
                                    break;
                                }
                            }

                            switch (input)
                            {
                                case ConsoleKey.Y:
                                    x.CreditCardInfo = InputCreditCardInfo.CreateCreditCard();
                                    Console.WriteLine("Payment method changed successfully!");
                                    AccountDataRW.WriteToJson(accounts);
                                    ChangeAccountDataPresentation.DisplayMenu(x);
                                    break;
                                case ConsoleKey.N:
                                    break;
                                default:
                                    Console.WriteLine("Invalid input. Try again.");
                                    break;
                            }
                            break;
                        case ConsoleKey.Escape:
                            AccountDataRW.WriteToJson(accounts);
                            LoggedInPresentation.DisplayMenu(x);
                            break;
                        case ConsoleKey.Tab:
                            AccountDataRW.WriteToJson(accounts);
                            LoggedInPresentation.DisplayMenu(x);
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Please enter a valid choice!");
                            Thread.Sleep(2000);
                            break;
                    }              
        }
        AccountDataRW.WriteToJson(accounts);
    }
}
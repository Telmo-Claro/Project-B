﻿using System.Net.Http.Headers;

public static class ChangeAccountDataLogic
{
    public static void ChangeName(Account account, string firstName, string lastName)
    {
        var accounts = AccountDataRW.ReadFromJson();
        if(AccountIsValid.IsValid(account, accounts))
        {
            account.FirstName = firstName;
            account.LastName = lastName;
        }
        AccountDataRW.WriteToJson(accounts);
    }
    
    public static void ChangeEmail(Account account, string email)
    {
        var accounts = AccountDataRW.ReadFromJson();
        if(AccountIsValid.IsValid(account, accounts))
        {
            account.Email = email;
        }
        AccountDataRW.WriteToJson(accounts);
    }
    
    public static void ChangePhoneNumber(Account account, string phoneNumber)
    {
        var accounts = AccountDataRW.ReadFromJson();
        if(AccountIsValid.IsValid(account, accounts))
        {
            account.PhoneNumber = phoneNumber;
        }
        AccountDataRW.WriteToJson(accounts);
    }

    
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
                            var newFirstName = Console.ReadLine();
                            x.FirstName = newFirstName;
                            Console.Write("\nEnter new last name: ");
                            var newLastName = Console.ReadLine();
                            x.LastName = newLastName;
                            if (x.FirstName == newFirstName)
                            {
                                Console.WriteLine("Name changed successfully!");
                            }
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
﻿using static System.Runtime.InteropServices.JavaScript.JSType;

public static class DisplayAccountInfo
{
    public static void AccountInfo(Account? account)
    {
        Console.Clear();
        Console.WriteLine("---------------- TRENLINES -----------------");
        Console.WriteLine($"Account name: {account.FirstName} {account.LastName}");
        Console.WriteLine($"Account email: {account.Email}");
        Console.WriteLine($"Account phone number: {account.PhoneNumber}");
        Console.WriteLine("--------------------------------------------");
    }

    public static void DeletedMessage()
    {
        Console.WriteLine("Account deleted succesfully");
        Console.ReadKey();
    }

    public static void NoAccInfo()
    {
        Console.WriteLine("No matches with the given credentials");
        Console.ReadKey();
    }

    public static void WrongChoice()
    {
        Console.WriteLine("Please enter a valid choice");
    }
}
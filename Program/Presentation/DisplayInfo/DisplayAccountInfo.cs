using static System.Runtime.InteropServices.JavaScript.JSType;

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
        Console.WriteLine($"CreditCard");
        Console.WriteLine($"Name: {account.CreditCardInfo.FirstName}");
        Console.WriteLine($"Surname: {account.CreditCardInfo.LastName}");
        Console.WriteLine($"Number: {account.CreditCardInfo.Number}");
        Console.WriteLine($"ExpirationDate: {account.CreditCardInfo.ExpirationDate}");
        Console.WriteLine($"CvcCode: {account.CreditCardInfo.CvcCode}");
        Console.WriteLine("--------------------------------------------");
    }
}
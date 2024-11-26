public static class DisplayCreditCardInfo
{
    public static void CreditCardInfo(Account? account)
    {
        if (account.CreditCardInfo is not null)
        {
            Console.WriteLine($"CreditCard Name: {account.CreditCardInfo.FirstName} {account.CreditCardInfo.LastName}\n" +
               $"CreditCard Number: {account.CreditCardInfo.Number}\n" +
               $"CreditCard Expiration Date: {account.CreditCardInfo.ExpirationDate}\n" +
               $"CreditCard CVC: {account.CreditCardInfo.CvcCode}\n" +
               "--------------------------------------------\n");
        }
        else
        {
            Console.WriteLine("No CreditCard Added");
            Console.WriteLine("--------------------------------------------\n");
        }
    }
}
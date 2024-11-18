public static class DisplayCreditCardInfo
{
    public static string CreditCardInfo(Account? account)
    {
        return "---------------- TRENLINES -----------------\n" +
               $"CreditCard Name: {account.CreditCardInfo.FirstName} {account.CreditCardInfo.LastName}\n" +
               $"CreditCard Number: {account.CreditCardInfo.Number}\n" +
               $"CreditCard Expiration Date: {account.CreditCardInfo.ExpirationDate}\n" +
               $"CreditCard CVC: {account.CreditCardInfo.CvcCode}\n" +
               "--------------------------------------------\n";
    }
}
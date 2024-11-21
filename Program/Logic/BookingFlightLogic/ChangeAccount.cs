public class ChangeAccount
{
    public static void ChangingAccount(Account account) // global method for adding booked flight, credit card and booking codes
    {
        var accounts = AccountDataRW.ReadFromJson();
        if (accounts is null) return;
        foreach (Account x in accounts)
        {
            if (x.FirstName == account.FirstName && x.LastName == account.LastName
                                                 && x.Email == account.Email && x.Password == account.Password)
            {
                x.BookedFlights = account.BookedFlights;
                x.BookingCodes = account.BookingCodes;
                x.CreditCardInfo = account.CreditCardInfo;
            }
        }
        AccountDataRW.WriteToJson(accounts);
    }
}
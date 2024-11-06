public class CreditCard : Payment
{
    public CreditCard(string? firstName, string? lastName, string? number, string expDate, string cvcCode)
        : base(firstName, lastName)
    {
        Number = number;
        ExpirationDate = expDate;
        CvcCode = cvcCode;

    }

    public void Pay()
    {
        throw new NotImplementedException();
    }
}
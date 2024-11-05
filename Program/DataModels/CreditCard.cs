public class CreditCard : IPay
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string IDealURL { get; set; }

    public CreditCard(string firstName, string lastName, string number)
    {
        FirstName = firstName;
        LastName = lastName;
        Number = number;
    }

    public void Pay()
    {
        throw new NotImplementedException();
    }
}
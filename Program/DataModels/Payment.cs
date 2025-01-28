public class Payment : IPay
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string ExpirationDate { get; set; }
    public string CvcCode { get; set; }

    protected const string _idealUrl = "https://tikkie.me/pay/ub7v65tff2av9kh65m6q";
    
    public Payment(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public Payment()
    {

    }

    public void Pay()
    {

    }
}

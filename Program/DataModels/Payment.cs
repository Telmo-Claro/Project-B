public class Payment
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string ExpirationDate { get; set; }
    public string CvcCode { get; set; }
    protected string _idealUrl { get; set; } = "https://tikkie.me/pay/99hmk7edsop5tts1lso8";


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
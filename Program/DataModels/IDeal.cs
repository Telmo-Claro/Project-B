public class IDeal : IPay
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string IDealURL { get; set; } = "https://tikkie.me/pay/99hmk7edsop5tts1lso8";

    public void Pay()
    {
        Console.WriteLine("Press X to pay with IDeal");
        System.Diagnostics.Process.Start(IDealURL);
        throw new NotImplementedException();
    }
}
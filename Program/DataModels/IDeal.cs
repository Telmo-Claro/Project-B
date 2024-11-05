namespace Program.DataModels;

public class IDeal : IPay
{
    private string IDealURL { get; set; } = "https://tikkie.me/pay/99hmk7edsop5tts1lso8";

    public void Pay()
    {
        Console.WriteLine("Press X to pay with IDeal");
        System.Diagnostics.Process.Start(IDealURL);
    }
}
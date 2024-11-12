public class IDeal : Payment
{
    public new void Pay()
    {
        Console.WriteLine("Press X to pay with IDeal");
        System.Diagnostics.Process.Start(_idealUrl);
    }
}
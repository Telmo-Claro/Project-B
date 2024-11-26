using System.Diagnostics;
public class IDeal : Payment
{
    public static new void Pay()
    {
        Process.Start(new ProcessStartInfo(_idealUrl) { UseShellExecute = true });
    }
}

public static class ErrorMessagePrinter
{
    public static void PrintError(Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


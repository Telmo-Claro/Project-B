public static class Catering
{
    public static (string? Catering, bool Valid) GetCatering(ConsoleKey key)
    {
        if (key == ConsoleKey.D1)
        {
            return ("Basic", true);
        }
        if (key == ConsoleKey.D2)
        {
            return ("Standard", true);
        }
        if (key == ConsoleKey.D3)
        {        
            return ("Premium", true);
        }
        if (key == ConsoleKey.D4)
        {
            return (null, true);
        }
        return (null, false);
    }
}


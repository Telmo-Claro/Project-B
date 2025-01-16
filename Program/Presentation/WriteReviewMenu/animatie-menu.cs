public static class StartupAnimation
{
    public static void ShowStartupLogo()
    {
        string[] logoLines = new string[]
        {
            "████████╗██████╗ ███████╗███╗   ██╗    ██╗     ██╗███╗   ██╗███████╗███████╗",
            "╚══██╔══╝██╔══██╗██╔════╝████╗  ██║    ██║     ██║████╗  ██║██╔════╝██╔════╝",
            "   ██║   ██████╔╝█████╗  ██╔██╗ ██║    ██║     ██║██╔██╗ ██║█████╗  ███████╗",
            "   ██║   ██╔══██╗██╔══╝  ██║╚██╗██║    ██║     ██║██║╚██╗██║██╔══╝  ╚════██║",
            "   ██║   ██║  ██║███████╗██║ ╚████║    ███████╗██║██║ ╚████║███████╗███████║",
            "   ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝    ╚══════╝╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝",
            "",
            "                    ╦ ╦╔═╗  ╔═╗╦ ╦ ╦  ╦ ╦╦╔╦╗╦ ╦  ╔═╗╦═╗╦ ╦═╗╔═╗",
            "                    ║║║║╣   ╠╣ ║ ╚╦╝  ║║║║ ║ ╠═╣  ╠═╝╠╦╝║ ║ ║║╣ ",
            "                    ╚╩╝╚═╝  ╩  ╩═ ╩   ╚╩╝╩ ╩ ╩ ╩  ╩  ╩╚ ╩ ╩═╝╚═╝"
        };

        Console.CursorVisible = false;
        SimulateRealisticLoading();
        Thread.Sleep(500);
        Console.Clear();
        DisplayLogo(logoLines);
            //yes
        Console.SetCursorPosition((Console.WindowWidth - 45) / 2, Console.WindowHeight - 4);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Press ENTER to continue or ESC to exit...");

        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                break;
            }
            if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Tab)
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }
    }

    private static void SimulateRealisticLoading()
    {
        string[] indicators = { "|", "/", "-", "\\" };
        Random random = new Random();
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;

        int loadingBarWidth = 30;
        int startX = (consoleWidth - loadingBarWidth - 10) / 2;
        int startY = consoleHeight / 2;

        Console.SetCursorPosition((consoleWidth - 20) / 2, startY - 2);
        Console.Write("System Loading...");

        for (int progress = 0; progress <= 100; progress++)
        {
            Console.SetCursorPosition((consoleWidth - 2) / 2, startY - 1);
            Console.Write(indicators[progress % indicators.Length]);

            Console.SetCursorPosition(startX, startY);
            Console.Write("[");
            int filled = progress * loadingBarWidth / 100;
            Console.Write(new string('=', filled));
            Console.Write(new string(' ', loadingBarWidth - filled));
            Console.Write($"] {progress}%");

            Thread.Sleep(random.Next(50, 110));
        }
    }

    private static void DisplayLogo(string[] logoLines)
    {
        ConsoleColor[] colors = {
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Blue,
            ConsoleColor.Magenta
        };

        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;
        int logoY = consoleHeight / 2 - logoLines.Length / 2;
        int colorIndex = 0;

        foreach (string line in logoLines)
        {
            Console.SetCursorPosition((consoleWidth - line.Length) / 2, logoY++);
            Console.ForegroundColor = colors[colorIndex % colors.Length];
            colorIndex++;

            foreach (char c in line)
            {
                Console.Write(c);
                Thread.Sleep(4);
            }
            Console.WriteLine();
        }
    }
}

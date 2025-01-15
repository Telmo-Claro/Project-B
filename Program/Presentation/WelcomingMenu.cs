public static class WelcomingMenu
{
    
    public static void Menu()
    {
        StartupAnimation.ShowStartupLogo();
        Console.ResetColor();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("WELCOME TO TRENLINES!");
            Console.WriteLine("---------------------");
            Console.WriteLine("(1) Log in");
            Console.WriteLine("(2) Create an account");
            Console.WriteLine("(ESC) Exit");
            Console.Write("> ");
            var input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine(input);
            if (input is "ESC" or "\t")
            {
                Environment.Exit(0);
            }
            switch (input)
            {
                case "1":
                    LoggingInPresentation.MenuDisplay();
                    break;
                case "2":
                    CreateAccountPresentation.DisplayMenu();
                    break;
                case "p":
                    Admin.AdminMenu();
                    break;
                default:
                    Console.Write("\nInvalid option. Please try again.");
                    Thread.Sleep(1000);
                    break;
            }
            
        }
    }
}
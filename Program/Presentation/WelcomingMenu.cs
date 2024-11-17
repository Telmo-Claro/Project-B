public static class WelcomingMenu
{
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("WELCOME TO TRENLINES!");
            Console.WriteLine("---------------------");

            Console.WriteLine("What do you wish to do:");
            Console.WriteLine("(1) Log in");
            Console.WriteLine("(2) Create an account");
            Console.WriteLine("(3) Exit");
            Console.Write("> ");
            switch (Console.ReadKey().KeyChar.ToString())
            {
                case "1":
                    LoginMenu.Login();
                    break;
                case "2":
                    CreateAccountMenu.CreateAccount();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                case "p":
                    Admin.AdminMenu();
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}
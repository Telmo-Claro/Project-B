public static class Menu
{
    public static void welcomingMenu()
    {
        while (true) {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("WELCOME TO ROTTERDAM AIRLINES!");
            Console.WriteLine("------------------------------");

            Console.WriteLine("What do you wish to do:");
            Console.WriteLine("(1) Log in.");
            Console.WriteLine("(2) Create an account.");
            Console.WriteLine("(3) Exit.");
            Console.Write("> ");
            string option = Console.ReadKey().KeyChar.ToString();
            if(option == "1")
            { 
                // implement Log In.
            }
            else if(option == "2")
            {
                // implement Create an Account.
            }
            else if(option == "3")
            {
                Environment.Exit(0);
            }
        }
    }
}

public static class Menu
{
    public static void welcomingMenu()
    {
        while (true) {
            Console.WriteLine("------------------------------");
            Console.WriteLine("WELCOME TO ROTTERDAM AIRLINES!");
            Console.WriteLine("------------------------------");

            Console.WriteLine("What do you wish to do:");
            Console.WriteLine("(1) Log in.");
            Console.WriteLine("(2) Create an account.");
            Console.WriteLine("(3) Exit");
            Console.Write("> ");
            var option = Console.ReadKey().ToString;
            if(option == "1")
            { 
                
            }

        }
    }
}

public static class LoggingInPresentation
{
    public static void MenuDisplay()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("------------------");
            Console.WriteLine("TRENLINES - LOG IN");
            Console.WriteLine("------------------");

            Console.WriteLine("Enter email [Q to exit]");
            string? email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email) || email.ToLower() == "q")
            {
                break;
            }

            // Check if email contains '@'
            if (!email.Contains("@"))
            {
                Console.WriteLine("Invalid email. Please ensure it contains an '@'.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine("Enter password [Q to exit]");
            string? password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password) || password.ToLower() == "q")
            {
                break;
            }

            // Call LoggingIn and check for null result
            var account = LoggingInLogic.LoggingIn(email, password);
            if (account != null)
            {
                LoggedInPresentation.DisplayMenu(account);
            }
            else
            {
                Console.WriteLine("Invalid email or password. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
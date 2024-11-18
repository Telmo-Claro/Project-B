public static class ManageAccountMenu
{
    public static void ManageAccount(Account account)
    {
        try
        {
            DisplayAccountInfo.AccountInfo(account);
            Console.WriteLine("(1) Change name");
            Console.WriteLine("(2) Change email");
            Console.WriteLine("(3) Change phone number");
            Console.WriteLine("(4) Change password");
            Console.WriteLine("(5) View CreditCard information");
            Console.WriteLine("(6) Go back");

            int choice;
            bool valid = false;
            while (!valid)
            {
                Console.Write("Please enter an option: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    AccountDataRW.ChangeData(account, choice);
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
        Console.ReadKey();
    }
}
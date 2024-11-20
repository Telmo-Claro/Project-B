public static class DeleteAccountPresentation
{
    public static void DisplayMenu(Account account)
    {
        try
        {
            DeleteAccountLogic.DeleteAccount(account.Email);
            Console.WriteLine("Account deleted successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
        Console.ReadKey();
    }
}
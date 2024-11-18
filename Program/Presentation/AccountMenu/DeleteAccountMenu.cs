public static class DeleteAccountMenu
{
    public static void DeleteAccount(Account account)
    {
        try
        {
            AccountDataRW.DeleteAccount(account.Email);
            Console.WriteLine("Account deleted successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
        Console.ReadKey();
    }
}
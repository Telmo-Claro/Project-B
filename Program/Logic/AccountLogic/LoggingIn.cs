public static class Logging_In
{
    public static Account? LoggingIn(string email, string password)
    {
        var accounts = AccountDataRW.ReadFromJson();
        if (accounts is null) return null;
        foreach (var account in accounts)
        {
            if (account.Email == email && account.Password == password)
            {
                return account;
            }
        }
        Console.WriteLine("No matches with the given credentials");
        Console.ReadKey();
        LoginMenu.Login();
        return null;
    }
}
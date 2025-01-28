public static class LoggingInLogic
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
        DisplayAccountInfo.NoAccInfo();
        LoggingInPresentation.MenuDisplay();
        return null;
    }
}
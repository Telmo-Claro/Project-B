public static class AccountIsValid
{
    public static bool IsValid(Account account, List<Account> accounts)
    {
        foreach (var x in accounts)
        {
            if (x == account)
            {
                return true;
            }
        }
        return false;
    }
}
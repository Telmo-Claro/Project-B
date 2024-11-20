public static class Add_account_logic
{
    public static void AddAccount(Account account)
    {
        var accounts = AccountDataRW.ReadFromJson();
        
        if (accounts != null)
        {
            var existingAccount = accounts.FirstOrDefault(x => x.Id == account.Id);
            if (existingAccount != null)
            {
                accounts.Remove(existingAccount);
                accounts.Add(account);
            }
            else
            {
                accounts.Add(account);
            }
        }
        AccountDataRW.WriteToJson(accounts);
    }
}
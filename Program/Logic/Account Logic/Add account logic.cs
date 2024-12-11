public static class AddAccountLogic
{
    public static void AddAccount(Account account)
    {
        var accounts = AccountDataRW.ReadFromJson();
        
        if (accounts != null)
        {
            // Telmo didnt add logic to increase the id... this is a fix
            // The ID's were added after this so I didnt know - Telmo 
            int Id = accounts[^1].Id + 1;
            account.Id = Id;
            // Telmo Brazilian 
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
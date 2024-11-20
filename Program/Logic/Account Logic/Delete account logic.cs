public class DeleteAccountLogic
{
    public static void DeleteAccount(string? email)
    {
        var accounts = AccountDataRW.ReadFromJson();
        if (accounts is null) return;

        var accountToRemove = accounts.FirstOrDefault(x => x.Email == email);
        if (accountToRemove != null)
        {
            accounts.Remove(accountToRemove);
            AccountDataRW.WriteToJson(accounts);
            Console.Clear();
            Console.WriteLine("Account deleted succesfully");

            Console.ReadKey();
            WelcomingMenu.Menu();
        }
    }
}
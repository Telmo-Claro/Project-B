using System.Net.Http.Headers;

public static class ChangeAccountDataLogic
{
    public static Account? ChangeName(Account account, string firstName, string lastName)
    {
        var accounts = AccountDataRW.ReadFromJson();
        foreach (var x in accounts)
        {
            Console.WriteLine(x);
            if (x.Email == account.Email && x.Password == account.Password)
            {
                x.FirstName = firstName;
                x.LastName = lastName;
                AccountDataRW.WriteToJson(accounts);
                return x;
            }
        }
        return null;
    }

    public static Account? ChangeEmail(Account account, string email)
    {
        var accounts = AccountDataRW.ReadFromJson();
        foreach (var x in accounts)
        {
            if (x.Email == account.Email && x.Password == account.Password)
            {
                x.Email = email;
                AccountDataRW.WriteToJson(accounts);
                return x;
            }
        }
        return null;
    }

    public static Account? ChangePhoneNumber(Account account, string phoneNumber)
    {
        var accounts = AccountDataRW.ReadFromJson();
        foreach (var x in accounts)
        {
            if (x.Email == account.Email && x.Password == account.Password)
            {
                x.PhoneNumber = phoneNumber;
                AccountDataRW.WriteToJson(accounts);
                return x;
            }
        }
        return null;
    }

    public static Account? ChangePassword(Account account, string password)
    {
        var accounts = AccountDataRW.ReadFromJson();
        foreach (var x in accounts)
        {
            if (x.Email == account.Email && x.Password == account.Password)
            {
                x.Password = password;
                AccountDataRW.WriteToJson(accounts);
                return x;
            }
        }
        return null;
    }

    public static Account? ChangeCreditCard(Account account, CreditCard creditCard)
    {
        var accounts = AccountDataRW.ReadFromJson();
        foreach (var x in accounts)
        {
            if (x.Email == account.Email && x.Password == account.Password)
            {
                AccountDataRW.WriteToJson(accounts);
                x.CreditCardInfo = creditCard;
                AccountDataRW.WriteToJson(accounts);
                return x;
            }
        }
        return null;
    }
}
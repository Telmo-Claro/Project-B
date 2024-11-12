public class ClassFactory
{
    public static CreditCard CreateCreditCard(string fname, string lname, string number, string date, string cvc)
    {
        CreditCard credit = new CreditCard(fname, lname, number, date, cvc);
        return credit;
    }

    public static Account CreateAccount(string firstName, string lastName,
        string email, string phoneNumber, string password)
    {
        Account account = new Account(firstName, lastName, email, phoneNumber, password);
        return account;
    }

    public static Account CreateAccount(string firstName, string lastName,
        string email, string phoneNumber, string password, Payment? creditCard)
    {
        Account account = new Account(firstName, lastName, email, phoneNumber, password, creditCard);
        return account;
    }
}
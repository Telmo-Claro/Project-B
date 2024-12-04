using System.Diagnostics;
using System.Net.Mail;
using System.Text.RegularExpressions;

public static class ValidateAccountInformation
{
    public static bool ValidateFirstName(string firstName)
    {
        Regex regex = new Regex(@"^[a-zA-Z]+$");
        return regex.IsMatch(firstName); 
    }

    public static bool ValidateLastName(string lastName)
    {
        Regex regex = new Regex(@"^[a-zA-Z]+$");
        return regex.IsMatch(lastName); 
    }

    public static bool ValidateEmail(string email)
    {
        try
        {
            MailAddress m = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool ValidatePassword(string password)
    {
        switch (password.Length)
        {
            case < 6:
                return false;
                break;
            default:
                return true;
        }
    }

    public static bool ValidatePhoneNumber(string phoneNumber)
    {
        switch (phoneNumber.Length)
        {
            case < 9:
            case > 12:
                return false;
            default:
                return true;
        }
    }
}
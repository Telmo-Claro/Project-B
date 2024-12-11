using System.Diagnostics;
using System.Net.Mail;
using System.Text.RegularExpressions;

public static class ValidateAccountInformation
{
    public static bool ValidateFirstName(string? firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return false;
        }
        Regex regex = new Regex(@"^[a-zA-Z]+$");
        return regex.IsMatch(firstName);
    }

    public static bool ValidateLastName(string? lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return false;
        }
        Regex regex = new Regex(@"^[a-zA-Z]+$");
        return regex.IsMatch(lastName);
    }

    public static bool ValidateEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
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

    public static bool ValidatePassword(string? password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;
        
        switch (password.Length)
        {
            case < 6:
                return false;
            default:
                return true;
        }
    }

    public static bool ValidatePhoneNumber(string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;
        if (!phoneNumber.All(char.IsDigit))
        {
            return false;
        }

        return phoneNumber.Length switch
        {
            < 9 or > 12 => false,
            _ => true
        };
    }
}
﻿using System.Globalization;

public class InputCreditCardInfo
{
    public static CreditCard CreateCreditCard()
    {
        // First Name Validation
        string fname;
        do
        {
            Console.Write("Enter card First Name: ");
            fname = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(fname) || !fname.All(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid name using only letters.");
                Console.ResetColor();
            }
        } while (string.IsNullOrWhiteSpace(fname) || !fname.All(char.IsLetter));

        // Last Name Validation
        string lname;
        do
        {
            Console.Write("Enter card Last Name: ");
            lname = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(lname) || !lname.All(char.IsLetter))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid name using only letters.");
                Console.ResetColor();
            }
        } while (string.IsNullOrWhiteSpace(lname) || !lname.All(char.IsLetter));

        // Card Number Validation
        string number;
        do
        {
            Console.Write("Enter card number (16 digits): ");
            number = Console.ReadLine()?.Trim() ?? string.Empty;

            if (number.Length != 16 || !number.All(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid card number. Please enter a 16-digit number.");
                Console.ResetColor();
            }
        } while (number.Length != 16 || !number.All(char.IsDigit));

        // Expiration Date Validation
        string date;
        bool validDate = false;
        do
        {
            Console.Write("Enter card Expiration Date (MM/yy): ");
            date = Console.ReadLine()?.Trim() ?? string.Empty;

            if (!DateTime.TryParseExact(date, "MM/yy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime parsedDate) || parsedDate <= DateTime.Now)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid or expired date. Please enter a future date in the format MM/yy.");
                Console.ResetColor();
            }
            else
            {
                validDate = true;
            }
        } while (!validDate);

        // CVC Validation
        string cvc;
        do
        {
            Console.Write("Enter card CVC Number (3 digits): ");
            cvc = Console.ReadLine()?.Trim() ?? string.Empty;

            if (cvc.Length != 3 || !cvc.All(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid CVC. Please enter a 3-digit number.");
                Console.ResetColor();
            }
        } while (cvc.Length != 3 || !cvc.All(char.IsDigit));

        return ClassFactory.CreateCreditCard(fname, lname, number, date, cvc);
    }
}
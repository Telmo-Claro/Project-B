public static class CreateAccountMenu
{
    public static void CreateAccount()
    {
        while (true)
        {
            string? firstName = "";
            string? lastName = "";
            string? email = "";
            string? password = "";
            string? phoneNumber = "";
            CreditCard? creditCard = null;
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("TRENLINES - CREATE ACCOUNT");
            Console.WriteLine("--------------------------");
            while (firstName == "")
            {
                Console.Write("First name: ");
                firstName = Console.ReadLine();
            }

            while (lastName == "")
            {
                Console.Write("Last name: ");
                lastName = Console.ReadLine();
            }

            while (email == "")
            {
                Console.Write("Enter email: ");
                email = Console.ReadLine();
            }

            while (phoneNumber == "")
            {
                Console.Write("Phone number: ");
                phoneNumber = Console.ReadLine();
            }

            while (password == "")
            {
                Console.Write("Enter password: ");
                password = Console.ReadLine();
            }

            bool choice = false;
            Console.Write("Do you want to add a CreditCard? Y/N: ");
            choice = Console.ReadKey().KeyChar.ToString().ToUpper() == "Y" ? true : false;
            if (choice)
            {
                Console.Clear();
                creditCard = InputCreditCardInfo.CreateCreditCard();
            }

            if (firstName != null && lastName != null
                                  && email != null && phoneNumber != null
                                  && password != null)
            {
                // firstName, lastName, email, phoneNumber, password
                Account? account = ClassFactory.CreateAccount(firstName, lastName, email, phoneNumber, password, creditCard);
                if (choice)
                {
                    account.CreditCardInfo = creditCard;
                }
                AccountDataRW.WriteJson(account);
                LoggedInMenu.LoggedIn(account);

            }
            break;
        }
    }
}
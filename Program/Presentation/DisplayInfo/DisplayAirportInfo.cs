using System.Security.Cryptography;

public class DisplayAirportInfo
{
    public static void DisplayMain(Account account)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"---------------- TRENLINES -----------------");
            Console.WriteLine($"Hey, {account.FirstName} {account.LastName}!");
            Console.WriteLine($"Welcome to the Rotterdam-Zuid Airport!");
            Console.WriteLine($"--------------------------------------------");

            Console.WriteLine("What do you wish to know about our airport?");
            Console.WriteLine("(1) Airport Facilities");
            Console.WriteLine("(2) Catering");
            Console.WriteLine("(3) Transportation");
            Console.WriteLine("(4) Other services");
            Console.WriteLine("(ESC) Go back");
            Console.Write("> ");

            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine($"\nAirport Facilities:");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nRestaurants & Cafes:\nA variety of dining options ranging from casual eateries to high-end restaurants. Special dietary needs are catered with vegan, vegetarian, gluten-free, and halal menus.");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nRetail Shops:\nDuty-free shops offering a wide range of products including cosmetics, perfumes, electronics, clothing, and souvenirs.");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nLounge Areas:\nPriority access lounges for business travelers featuring comfortable seating areas with Wi-Fi, power outlets, and entertainment options. Includes complimentary beverages and snacks.");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nMedical Facilities:\nOn-site clinics providing medical assistance 24/7 including minor surgeries, X-rays, prescription services, etc.");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nBaggage Services:\nBaggage storage facilities available for up to 24 hours before departure or pick-up by designated airport staff.");
                    Thread.Sleep(500);
                    Console.WriteLine($"--------------------------------------------");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine($"\nCatering:");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nIn-flight Meals & Snacks:\n A selection of meals and snacks prepared in partnership with renowned chefs. Options include international cuisine, vegetarian, kosher, halal, and low-carb diets.");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nOn-Site Dining:\nVarious restaurants and cafes serving breakfast, lunch, dinner, and late-night options for all travelers.");
                    Thread.Sleep(500);
                    Console.WriteLine($"--------------------------------------------");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine($"\nTransportation:");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nGround Transport:\nShuttle services to major cities within a 50-kilometer radius. Pre-bookable through the airport app with pickup points at hotels and residential areas.");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nCar Rental:\nPartnered car rental services located in dedicated lots near the entrance, offering a variety of vehicles including economy, luxury, SUVs, and electric cars.");
                    Thread.Sleep(500);
                    Console.WriteLine($"--------------------------------------------");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine($"\nOther services:");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nAssistance Dogs:\nTrained assistance dogs are allowed on board with proper documentation; facilities provided to accommodate these animals.");
                    Thread.Sleep(500);
                    Console.WriteLine(
                        $"\nWheelchair & Mobility Support:\nWheelchairs available for rent at the airport kiosks. Staff members are trained to assist travelers with mobility challenges in navigating through terminals and boarding gates.");
                    Thread.Sleep(500);
                    Console.WriteLine($"--------------------------------------------");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.Tab:
                    LoggedInPresentation.DisplayMenu(account);
                    break;
                case ConsoleKey.Escape:
                    LoggedInPresentation.DisplayMenu(account);
                    break;
                default:
                    Console.WriteLine("Please enter a valid input.");
                    break;
            }
        }
    }
}
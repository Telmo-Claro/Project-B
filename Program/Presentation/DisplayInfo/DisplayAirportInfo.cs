public class DisplayAirportInfo
{
    public static void DisplayMain(Account account)
    {
        // Part 1
        Console.Clear();
        Console.WriteLine($"---------------- TRENLINES -----------------");
        Console.WriteLine($"Hey, {account.FirstName} {account.LastName}!");
        Console.WriteLine($"Welcome to the Rotterdam-Zuid Airport!");
        Console.WriteLine($"--------------------------------------------");
        
        Console.WriteLine($"Airport Facilities:");
        Thread.Sleep(1000);
        Console.WriteLine($"\nRestaurants & Cafes:\nA variety of dining options ranging from casual eateries to high-end restaurants. Special dietary needs are catered with vegan, vegetarian, gluten-free, and halal menus.");
        Thread.Sleep(5000);
        Console.WriteLine($"\nRetail Shops:\nDuty-free shops offering a wide range of products including cosmetics, perfumes, electronics, clothing, and souvenirs.");
        Thread.Sleep(5000);
        Console.WriteLine($"\nLounge Areas:\nPriority access lounges for business travelers featuring comfortable seating areas with Wi-Fi, power outlets, and entertainment options. Includes complimentary beverages and snacks.");
        Thread.Sleep(5000);
        Console.WriteLine($"\nMedical Facilities:\nOn-site clinics providing medical assistance 24/7 including minor surgeries, X-rays, prescription services, etc.");
        Thread.Sleep(5000);
        Console.WriteLine($"\nBaggage Services:\nBaggage storage facilities available for up to 24 hours before departure or pick-up by designated airport staff.");
        Thread.Sleep(2000);
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        
        // Part 2
        Console.Clear();
        Console.WriteLine($"---------------- TRENLINES -----------------");
        Console.WriteLine($"Hey, {account.FirstName} {account.LastName}!");
        Console.WriteLine($"Welcome to the Rotterdam-Zuid Airport!");
        Console.WriteLine($"--------------------------------------------");
        
        Console.WriteLine($"Catering:");
        Thread.Sleep(1000);
        Console.WriteLine($"\nIn-flight Meals & Snacks:\n A selection of meals and snacks prepared in partnership with renowned chefs. Options include international cuisine, vegetarian, kosher, halal, and low-carb diets.");
        Thread.Sleep(5000);
        Console.WriteLine($"\nOn-Site Dining:\nVarious restaurants and cafes serving breakfast, lunch, dinner, and late-night options for all travelers.");
        Thread.Sleep(2000);
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        
        
        // Part 3
        Console.Clear();
        Console.WriteLine($"---------------- TRENLINES -----------------");
        Console.WriteLine($"Hey, {account.FirstName} {account.LastName}!");
        Console.WriteLine($"Welcome to the Rotterdam-Zuid Airport!");
        Console.WriteLine($"--------------------------------------------");
        
        Console.WriteLine($"Transportation:");
        Thread.Sleep(1000);
        Console.WriteLine($"\nGround Transport:\nShuttle services to major cities within a 50-kilometer radius. Pre-bookable through the airport app with pickup points at hotels and residential areas.");
        Thread.Sleep(5000);
        Console.WriteLine($"\nCar Rental:\nPartnered car rental services located in dedicated lots near the entrance, offering a variety of vehicles including economy, luxury, SUVs, and electric cars.");
        Thread.Sleep(2000);
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        
        // Part 4
        Console.Clear();
        Console.WriteLine($"---------------- TRENLINES -----------------");
        Console.WriteLine($"Hey, {account.FirstName} {account.LastName}!");
        Console.WriteLine($"Welcome to the Rotterdam-Zuid Airport!");
        Console.WriteLine($"--------------------------------------------");
        
        Console.WriteLine($"Other services:");
        Thread.Sleep(1000);
        Console.WriteLine($"\nAssistance Dogs:\nTrained assistance dogs are allowed on board with proper documentation; facilities provided to accommodate these animals.");
        Thread.Sleep(5000);
        Console.WriteLine($"\nWheelchair & Mobility Support:\nWheelchairs available for rent at the airport kiosks. Staff members are trained to assist travelers with mobility challenges in navigating through terminals and boarding gates.");
        Thread.Sleep(2000);
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public static class Admin
{
    private static readonly string adminUsername = "snus";
    private static readonly string adminPassword = "snus";

    public static void AdminMenu()
    {
        if (!AdminLogin())
        {
            Console.WriteLine("");
            Console.WriteLine("Access denied\nPress any key to return to the menu.");
            Console.ReadKey();
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("-------------");
            Console.WriteLine("ADMIN PANEL");
            Console.WriteLine("--------------");
            Console.WriteLine("(1) View all flights");
            Console.WriteLine("(2) Add a new flight");
            Console.WriteLine("(3) Delete a flight");
            Console.WriteLine("(4) Exit");
            Console.Write("> ");
            string option = Console.ReadKey().KeyChar.ToString();

            if (option == "1")
            {
                ViewFlightsMethod();
            }
            // else if (option == "2")
            // {
            //     AddFlight();
            // }
            // else if (option == "3")
            // {
            //     DeleteFlight();
            // }
            else if (option == "4")
            {
                break;
            }
        }
    }

    private static bool AdminLogin() // done
    {
        Console.Clear();
        Console.WriteLine("---- ADMIN LOGIN ----");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (username == adminUsername && password == adminPassword)
        {
            Console.WriteLine("");
            Console.WriteLine("Access granted.\nPress any key to continue.");
            Console.ReadKey();
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void ViewFlightsMethod() // done 
    {
        int page = 1;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Displaying all flights:");
            ViewFlights.View(page);
            Console.WriteLine($"Page: {page}");

            Console.WriteLine("Press any key to return");
            page = PageScroller.NextPage(Console.ReadKey().Key, page);
        }
    }


    // public static void AddFlight() //  
    // {
    //     Console.Clear();
    //     // Code to add a flight
    //     Console.WriteLine("Enter flight details to add a new flight.");
    //     Console.WriteLine("Press any key to return.");
    //     Console.ReadKey();
    // }

    // public static void DeleteFlight() 
    // {
    //     Console.Clear();
    //     Console.Write("Enter the flight number to delete: ");
    //     string flightNumber = Console.ReadLine();

    //     if (FlightDataRW.DeleteFlight(flightNumber))
    //     {
    //         Console.WriteLine($"Flight {flightNumber} deleted successfully.");
    //     }
    //     else
    //     {
    //         Console.WriteLine($"Flight {flightNumber} not found.");
    //     }

    //     Console.WriteLine("Press any key to continue.");
    //     Console.ReadKey();
    // }
}

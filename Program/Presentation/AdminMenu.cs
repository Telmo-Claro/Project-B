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
            else if (option == "3")
            {
                DeleteFlight();
            }
            else if (option == "4")
            {
                break;
            }
        }
    }

    private static bool AdminLogin() 
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

    public static void ViewFlightsMethod() 
    {
        int page = 1;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Displaying all flights:");
            ViewFlights.View(page);
            Console.WriteLine($"Page: {page}");

            Console.WriteLine("Press X to return to the menu");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.X)
            {
                break; 
            }
            page = PageScroller.NextPage(Console.ReadKey().Key, page);
        }
    }
    
    public static void DeleteFlight()
    {
        List<Flight> flightList = FlightDataRW.ReadJson();
        Console.Clear();

        while (true)
        {
            Console.WriteLine("Enter the flight number to delete\nType '/Quit' to return to the menu");
            string input = Console.ReadLine();

            
            if (input == "/Quit") // '/Quit' ipv 'any key' om misclicks te voorkomen. 
            {
                return; 
            }

            Flight flightToRemove = null;

            
            foreach (var flight in flightList)
            {
                if (flight.FlightNumber.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    flightToRemove = flight;
                    break; 
                } /* ^ Dit stukje zoekt in een lijst van vluchten naar een specifieke vlucht(=input van user)
            wanneer de vlucht is gevonden, wordt deze opgeslagen, en stopt de loop. */
            } 
            
            if (flightToRemove == null) 
            {
                Console.WriteLine("No flight found with that number. Please try again.");
                continue; 
            }
            
            Console.Clear();
            Console.WriteLine("Flight Details:");
            Console.WriteLine($"    Flight Number: {flightToRemove.FlightNumber}");
            Console.WriteLine($"    Departure: {flightToRemove.Departure}");
            Console.WriteLine($"    Destination: {flightToRemove.Destination}");
            Console.WriteLine($"    Date: {flightToRemove.Date}");
            Console.WriteLine($"    Time Departure: {flightToRemove.TimeDeparture}");
            Console.WriteLine($"    Time Arrival: {flightToRemove.TimeArrival}");
            Console.WriteLine($"    Duration: {flightToRemove.Duration}");
            Console.WriteLine($"    Status: {flightToRemove.Status}");
            Console.WriteLine($"    Aircraft:{flightToRemove.Aircraft}");
            Console.WriteLine("\nIf this is the correct flight?\nPress 1 to continue\nPress 2 to go back.");

            string confirmInput = Console.ReadLine();

            
            if (confirmInput == "2")
            {
                continue; 
            }
            
            if (confirmInput == "1")
            {
                Console.WriteLine("\nAre you sure you want to delete this flight? \n1) Yes\n2) No");
                confirmInput = Console.ReadLine();

                if (confirmInput == "1")
                {
                    flightList.Remove(flightToRemove);
                    FlightDataRW.WriteJson(flightList);
                    Console.WriteLine("Flight deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Operation cancelled. Returning to flight selection.");
                    continue; 
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1 to continue or 2 to go back.");
            }
        }
    }
}

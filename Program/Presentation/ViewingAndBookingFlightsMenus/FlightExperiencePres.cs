public static class FlightExperiencePres
{
    public static void FlightExperience(Flight flight)
    {
        Console.Clear();
        var service = new FlightExperienceService();
        var availableTimeslots = service.CalculateAvailableTimeslots(flight.Duration);

        // Check if there are available timeslots
        if (availableTimeslots.Count == 0)
        {
            FlightBooking.FlightExperienceBool = false;
            Console.WriteLine("No available timeslots");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("The timeslots are shown in post departure time.\n");
        Console.WriteLine("Available Timeslots:");
        foreach (var slot in availableTimeslots)
        {
            if (!flight.SelectedTimeslots.Contains(slot))
            {
                Console.WriteLine(slot);
            }
        }

        // Let the user select a timeslot
        Console.WriteLine("Please select a timeslot from the available options:");

        TimeSpan selectedTimeslot = TimeSpan.Zero;
        bool isValid = false;

        while (!isValid)
        {
            var userInput = Console.ReadLine();

            // Try to parse the input to a valid TimeSpan
            if (TimeSpan.TryParse(userInput, out selectedTimeslot) && availableTimeslots.Contains(selectedTimeslot) && !flight.SelectedTimeslots.Contains(selectedTimeslot))
            {
                isValid = true; // If valid, break out of the loop
            }
            else
            {
                Console.WriteLine("Invalid timeslot selected. Please choose a valid option from the available timeslots.");
            }
        }

        // Book the selected timeslot for this flight
        flight.SelectedTimeslots.Add(selectedTimeslot);

        Console.WriteLine($"Timeslot {selectedTimeslot} successfully booked for the flight.");
    }
}
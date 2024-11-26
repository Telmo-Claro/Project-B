public static class FlightExperiencePres
{
    public static void FlightExperience(Flight flight)
    {
        var service = new FlightExperienceService();
        var availableTimeslots = service.CalculateAvailableTimeslots(flight.Duration);

        // Check if there are available timeslots
        if (availableTimeslots.Count == 0)
        {
            throw new InvalidOperationException("No available timeslots.");
        }

        Console.WriteLine("Available Timeslots:");
        foreach (var slot in availableTimeslots)
        {
            Console.WriteLine(slot);
        }

        // Let the user select a timeslot
        Console.WriteLine("Please select a timeslot from the available options:");
        
        TimeSpan selectedTimeslot = TimeSpan.Zero; // Initialize the variable
        bool isValid = false;
        
        while (!isValid)
        {
            var userInput = Console.ReadLine();

            // Try to parse the input to a valid TimeSpan
            if (TimeSpan.TryParse(userInput, out selectedTimeslot) && availableTimeslots.Contains(selectedTimeslot))
            {
                isValid = true; // If valid, break out of the loop
            }
            else
            {
                Console.WriteLine("Invalid timeslot selected. Please choose a valid option from the available timeslots.");
            }
        }

        // Check if the selected timeslot is already booked
        if (flight.SelectedTimeslots.Contains(selectedTimeslot))
        {
            throw new InvalidOperationException("This timeslot has already been booked.");
        }

        // Book the selected timeslot for this flight
        flight.SelectedTimeslots.Add(selectedTimeslot);

        Console.WriteLine($"Timeslot {selectedTimeslot} successfully booked for the flight.");
    }


}
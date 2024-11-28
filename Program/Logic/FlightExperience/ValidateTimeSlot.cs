public class ValidateTimeSlot
{
    public void AddTimeSlot(Flight flight, TimeSpan? selectedTimeslot)
    {
        // make sure the flight has available timeslots
        var service = new FlightExperienceService();
        var availableTimeslots = service.CalculateAvailableTimeslots(flight.Duration);

        if (selectedTimeslot.HasValue && !availableTimeslots.Contains(selectedTimeslot.Value))
        {
            throw new ArgumentException("Invalid timeslot selected.");
        }

        if (flight.SelectedTimeslots.Contains(selectedTimeslot.Value))
        {
            throw new InvalidOperationException("This timeslot has already been booked.");
        }

        // Add the new timeslot
        flight.SelectedTimeslots.Add(selectedTimeslot.Value);
    }
}
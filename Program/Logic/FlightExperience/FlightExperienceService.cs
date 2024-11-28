public class FlightExperienceService
{
    public List<TimeSpan> CalculateAvailableTimeslots(TimeSpan flightDuration)
    {
        int bufferTimeMinutes = 30;
        int experienceDurationMinutes = 30;
        var availableTimeslots = new List<TimeSpan>();
        // make sure flight is long enough for the experience
        if (flightDuration.TotalMinutes < 2 * bufferTimeMinutes + experienceDurationMinutes)
            return availableTimeslots;

        // calculate start and end time
        TimeSpan start = TimeSpan.FromMinutes(bufferTimeMinutes);
        TimeSpan end = flightDuration - TimeSpan.FromMinutes(bufferTimeMinutes + experienceDurationMinutes);

        while (start <= end)
        {
            availableTimeslots.Add(start);
            start += TimeSpan.FromMinutes(experienceDurationMinutes);
        }

        return availableTimeslots;
    }
}

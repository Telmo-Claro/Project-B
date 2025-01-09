public static class FeedbackLogic
{
    public static void AddFeedback(string? message, DateTime? date)
    {
        var reviews = AppFeedbackRW.ReadJson();
        Feedback newFeedback = new Feedback(message, date);
        if (!reviews.Contains(newFeedback))
        {
            reviews.Add(newFeedback);
        }
        AppFeedbackRW.WriteJson(reviews);
    }
}
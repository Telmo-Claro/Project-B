public static class FeedbackLogic
{
    public static void AddFeedback(string? message)
    {
        var reviews = AppFeedbackRW.ReadJson();
        Feedback newFeedback = new Feedback(message);
        if (!reviews.Contains(newFeedback))
        {
            reviews.Add(newFeedback);
        }
        AppFeedbackRW.WriteJson(reviews);
    }
}
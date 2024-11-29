public static class FeedbackLogic
{
    public static void AddFeedback(Account account, string? message)
    {
        var reviews = AppFeedbackRW.ReadJson();
        Feedback newFeedback = new Feedback(account, message);
        if (!reviews.Contains(newFeedback))
        {
            reviews.Add(newFeedback);
        }
        AppFeedbackRW.WriteJson(reviews);
    }
}
using System.Text.Json.Serialization;

public class Feedback
{
    [JsonPropertyName("User")]
    public Account FromAccount { get; set; }
    [JsonPropertyName("Feedback")]
    public string? FeedbackMessage { get; set; }

    public Feedback(Account fromAccount, string? feedbackMessage)
    {
        FromAccount = fromAccount;
        FeedbackMessage = feedbackMessage;
    }
}
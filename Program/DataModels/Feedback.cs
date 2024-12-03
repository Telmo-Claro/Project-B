using System.Text.Json.Serialization;

public class Feedback
{
    [JsonPropertyName("Feedback")]
    public string? FeedbackMessage { get; set; }

    public Feedback(string? feedbackMessage)
    {
        FeedbackMessage = feedbackMessage;
    }
}
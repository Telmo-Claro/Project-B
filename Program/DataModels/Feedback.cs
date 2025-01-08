using System.Text.Json.Serialization;

public class Feedback
{
    [JsonPropertyName("Feedback")]
    public string? FeedbackMessage { get; set; }
    public DateTime? Date {get; set;}

    public Feedback(string? feedbackMessage, DateTime? date)
    {
        FeedbackMessage = feedbackMessage;
        Date = date;
    }
}
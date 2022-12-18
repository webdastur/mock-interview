using System.Text.Json.Serialization;

namespace Application.Services.ReservedInterviews;

public class ReservedInterviewCreateModel
{
    [JsonPropertyName("interview_id")]
    public int InterviewId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

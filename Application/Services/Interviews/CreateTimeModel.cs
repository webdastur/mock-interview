using System.Text.Json.Serialization;

namespace Application.Services.Interviews;

public class CreateTimeModel
{
    [JsonPropertyName("strat_time")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("week_days")]
    public string WeekDays { get; set; }


    [JsonPropertyName("interview_id")]
    public required int InterviewId { get; set; }
}

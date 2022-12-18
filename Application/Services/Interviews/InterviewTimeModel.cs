using Application.Common.Model;
using Domain.Enums;
using System.Text.Json.Serialization;

namespace Application.Services.Interviews;

public class InterviewTimeModel : BaseModel
{
    [JsonPropertyName("strat_time")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("week_days")]
    public string WeekDays { get; set; }
}

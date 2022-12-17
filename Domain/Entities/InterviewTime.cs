using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class InterviewTime : BaseEntity
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public WeekDays WeekDays { get; set; }

    public int InterviewId { get; set; }
}

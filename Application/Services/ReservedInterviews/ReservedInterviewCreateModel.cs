namespace Application.Services.ReservedInterviews;

public class ReservedInterviewCreateModel
{
    public int UserId { get; set; }
    public int InterviewId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

using Domain.Entities.Base;

namespace Domain.Entities;
public class ReservedInterview : AuditableEntity
{
    public int UserId { get; set; }
    public int InterviewId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<Payment> Payments { get; set; }

    public User User { get; set; }
    public Interview Interview { get; set; }
}

using Domain.Entities.Base;

namespace Domain.Entities; 
public class Interview : AuditableEntity
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public ICollection<InterviewTime> Times { get; set; }
    public ICollection<InterviewLevel> Levels { get; set; }

    public InterviewCategory Category { get; set; }
    public User User { get; set; }
}

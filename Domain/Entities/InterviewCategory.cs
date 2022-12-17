using Domain.Entities.Base;

namespace Domain.Entities;

public class InterviewCategory : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}

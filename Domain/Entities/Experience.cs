using Domain.Entities.Base;

namespace Domain.Entities;

public class Experience : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int LevelId { get; set; }
    public int UserId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public User User { get; set; }
    public Level Level { get; set; }
}

using Domain.Entities.Base;

namespace Domain.Entities;

public class Project : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public int? ImageId { get; set; }
    public int UserId { get; set; }

    public File Image { get; set; }
    public User User { get; set; }
}

using Domain.Entities.Base;

namespace Domain.Entities;
public class Level : AuditableEntity
{
    public string Name { get; set; }
}

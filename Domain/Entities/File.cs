using Domain.Entities.Base;

namespace Domain.Entities; 
public class File : BaseEntity
{
    public string Name { get; set; }
    public string Path { get; set; }
}

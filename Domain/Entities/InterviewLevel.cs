using Domain.Entities.Base;

namespace Domain.Entities;

public class InterviewLevel : BaseEntity
{
    public int LevelId { get; set; }
    public int InterviewId { get; set; }
    public decimal Price { get; set; }

    public Level Level { get; set; }
    public Interview Interview { get; set; }
}

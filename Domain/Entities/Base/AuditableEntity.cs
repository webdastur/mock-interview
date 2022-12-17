namespace Domain.Entities.Base;

public class AuditableEntity : BaseEntity
{
    private DateTime updatedAt { get; set; }
    private int updateUserId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt
    {
        get
        {
            return (updatedAt == DateTime.MinValue ? this.CreatedAt : updatedAt);
        }
        set
        {
            updatedAt = value;
        }
    }

    public int CreatedUserId { get; set; }
    public int UpdatedUserId
    {
        set
        {
            updateUserId = value;
        }
        get
        {
            return (updateUserId == 0 && this.CreatedUserId != 0) ? this.CreatedUserId : updateUserId;
        }
    }
}

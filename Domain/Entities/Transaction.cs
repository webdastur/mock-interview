using Domain.Entities.Base;

namespace Domain.Entities; 
public class Transaction : AuditableEntity
{
    public string TransactionId { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime PerformTime { get; set; }
    public DateTime CancelTime { get; set; }
    public decimal Amount { get; set; }
}

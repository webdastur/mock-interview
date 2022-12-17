using Domain.Enums;
using Domain.Entities.Base;

namespace Domain.Entities;

public class Payment : BaseEntity
{
    public int TransactionId { get; set; }
    public int InterviewId { get; set; }
    public int UserId { get; set; }
    public PaymentStatus Status { get; set; }

    public Transaction Transaction { get; set; }
    public ReservedInterview Interview { get; set; }
    public User User { get; set; }
}

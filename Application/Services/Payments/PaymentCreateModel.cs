using Domain.Enums;

namespace Application.Services.Payments;

public class PaymentCreateModel
{
    public int InterviewId { get; set; }
    public string Status { get; set; } = PaymentStatus.Paid.ToString();
}

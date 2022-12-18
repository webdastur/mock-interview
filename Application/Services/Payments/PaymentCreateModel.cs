using Domain.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Services.Payments;

public class PaymentCreateModel
{
    [JsonPropertyName("reserved_interview_id")]
    public int InterviewId { get; set; }
    public string Status { get; set; } = PaymentStatus.Paid.ToString();
}

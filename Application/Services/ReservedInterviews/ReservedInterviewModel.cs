using Application.Common.Model;
using Application.Services.Interviews;
using Application.Services.Payments;

namespace Application.Services.ReservedInterviews;

public class ReservedInterviewModel : BaseModel
{
    public int UserId { get; set; }
    public int InterviewId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<PaymentModel> Payments { get; set; }
    public InterviewModel Interview { get; set; }
}

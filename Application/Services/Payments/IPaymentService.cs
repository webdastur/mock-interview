using Application.Common.Model;
using Application.Services.ReservedInterviews;

namespace Application.Services.Payments;

public interface IPaymentService
{
    PaymentModel Create(PaymentCreateModel paymentCreateModel);
    ValueTask<PaginatedList<PaymentModel>> GetPaymets(PaginatedRequestModel paginatedRequestModel);

}

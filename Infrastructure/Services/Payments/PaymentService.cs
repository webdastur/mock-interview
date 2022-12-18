using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.Interviews;
using Application.Services.Payments;
using Application.Services.Users;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Auth;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Payments;

public class PaymentService : IPaymentService
{
    private readonly IRepository<Payment> paymentRepository;
    private readonly IMapper mapper;
    private readonly ICurrentUser currentUser;

    public PaymentService(IRepository<Payment> paymentRepository, IMapper mapper,ICurrentUser currentUser)
    {
        this.paymentRepository = paymentRepository;
        this.mapper = mapper;
        this.currentUser = currentUser;
    }
    public PaymentModel Create(PaymentCreateModel paymentCreateModel)
    {
        if (paymentCreateModel is not null && !paymentCreateModel.Status.Equals(PaymentStatus.Paid.ToString()))
            throw new Exception("Payment is not complete or there is an error during the payment process");

        Payment mappedPayment = mapper.Map<Payment>(paymentCreateModel);
        mappedPayment.UserId = currentUser.GetUserId();
        
        paymentRepository.Add(mappedPayment);

        return mapper.Map<PaymentModel>(mappedPayment);
    }

    public async ValueTask<PaginatedList<PaymentModel>> GetPaymets(PaginatedRequestModel paginatedRequestModel)
    {
        int count = await paymentRepository.GetCountAsync();

        List<Payment> interviews = await paymentRepository.GetAllByIncPage(
            paginatedRequestModel.Page,
                paginatedRequestModel.PageSize,
                   query => query.OrderByDescending(order => order.Id),
                       new string[] { "Interview" })
                           .ToListAsync();

        var paymentsModels = mapper.Map<List<PaymentModel>>(interviews);

        return new PaginatedList<PaymentModel>
            (
                items: paymentsModels,
                count: count,
                pageNumber: paginatedRequestModel.Page,
                pageSize: paginatedRequestModel.PageSize
            );
    }
}

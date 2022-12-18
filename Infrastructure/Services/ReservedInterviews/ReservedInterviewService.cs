using AutoMapper;
using Domain.Entities;
using Application.Common.Model;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Application.Services.ReservedInterviews;

namespace Infrastructure.Services.ReservedInterviews
{
    public class ReservedInterviewService : IReservedInterviewService
    {
        private readonly IRepository<ReservedInterview> reservedInterviewRepository;
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUser;

        public ReservedInterviewService(IRepository<ReservedInterview> reservedInterviewRepository, IMapper mapper,ICurrentUser currentUser)
        {
            this.reservedInterviewRepository = reservedInterviewRepository;
            this.mapper = mapper;
            this.currentUser = currentUser;
        }
        public ReservedInterviewModel Create(ReservedInterviewCreateModel reservedInterviewCreateModel)
        {
            ReservedInterview mappedReservedInterview = mapper.Map<ReservedInterview>(reservedInterviewCreateModel);
            mappedReservedInterview.UserId = currentUser.GetUserId();
            reservedInterviewRepository.Add(mappedReservedInterview);
            return mapper.Map<ReservedInterviewModel>(mappedReservedInterview);
        }

        public async ValueTask<ReservedInterviewModel> GetById(int reservedInterviewId)
        {
            ReservedInterview reservedInterviewEntity = await reservedInterviewRepository.GetByIdAsync(reservedInterviewId);
            
            if (reservedInterviewEntity is null)
                throw new Exception("ReservedInterview not found");
            
            return mapper.Map<ReservedInterviewModel>(reservedInterviewEntity);
        }

        public async ValueTask<PaginatedList<ReservedInterviewModel>> GetReservedInterviews(PaginatedRequestModel paginatedRequestModel)
        {
            int count = await reservedInterviewRepository.GetCountAsync();

            List<ReservedInterview> reservedInterviews = await reservedInterviewRepository.GetAllByIncPage(
                paginatedRequestModel.Page,
                    paginatedRequestModel.PageSize,
                       query => query.OrderByDescending(order => order.UpdatedAt),
                            new string[] { "Payments" })
                               .ToListAsync();

            var reservedInterviewsModels = mapper.Map<List<ReservedInterviewModel>>(reservedInterviews);

            return new PaginatedList<ReservedInterviewModel>
                (
                    items: reservedInterviewsModels,
                    count: count,
                    pageNumber: paginatedRequestModel.Page,
                    pageSize: paginatedRequestModel.PageSize
                );


        }
    }
}

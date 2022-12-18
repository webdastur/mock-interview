using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.Interviews;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Interviews;

public class InterviewService : IInterviewService
{
    private readonly IRepository<Interview> interviewRespository;
    private readonly IMapper mapper;
    private readonly ICurrentUser currentUser;

    public InterviewService(
        IRepository<Interview> interviewRespository, 
        IMapper mapper,
        ICurrentUser currentUser)
    {
        this.interviewRespository = interviewRespository;
        this.mapper = mapper;
        this.currentUser = currentUser;
    }

    public InterviewModel CreateInterview(InterviewCreateModel interviewModel)
    {
        var mappingInterviewModel = mapper.Map<Interview>(interviewModel);
        mappingInterviewModel.UserId = currentUser.GetUserId();

        interviewRespository.Add(mappingInterviewModel);

        return mapper.Map<InterviewModel>(mappingInterviewModel);
    }

    public async Task<PaginatedList<InterviewModel>> GetAllInterviews(PaginatedRequestModel paginatedRequestModel)
    {
        int count = await interviewRespository.GetCountAsync();

        List<Interview> interviews = await interviewRespository.GetAllByIncPage(
            paginatedRequestModel.Page,
                paginatedRequestModel.PageSize,
                   query => query.OrderByDescending(order => order.UpdatedAt),
                       new string[] { "Category", "User", "Times"})
                           .ToListAsync();

        var interviewModels = mapper.Map<List<InterviewModel>>(interviews);

        return new PaginatedList<InterviewModel>
            (
                items: interviewModels,
                count: count,
                pageNumber: paginatedRequestModel.Page,
                pageSize: paginatedRequestModel.PageSize
            );
    }
}

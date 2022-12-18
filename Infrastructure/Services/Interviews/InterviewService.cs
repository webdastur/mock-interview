using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.Interviews;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Helpers;

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
                   query => query.OrderByField(paginatedRequestModel.FieldName, paginatedRequestModel.IsAsc),
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

    public async Task<PaginatedList<InterviewModel>> GetByFilteredInterviews(FilteredRequestModel paginatedRequestModel)
    {
        if (paginatedRequestModel.Search.Any())
        {
            return await GetBySearch(paginatedRequestModel);
        }
        else
        {
            return await GetWithoutSearch(paginatedRequestModel);
        }
    }

    private async Task<PaginatedList<InterviewModel>> GetBySearch(FilteredRequestModel paginatedRequestModel)
    {
        int count = await interviewRespository.GetCountExpAsync(x => x.Title.ToLower().Contains(paginatedRequestModel.Search.ToLower()));

        List<Interview> interviews = await interviewRespository.GetAllByExpIncPage(
             paginatedRequestModel.Page,
                paginatedRequestModel.PageSize,
                   query => query.Title.ToLower().Contains(paginatedRequestModel.Search.ToLower()),
                       query => query.OrderByField(paginatedRequestModel.FieldName, paginatedRequestModel.IsAsc),
                           new string[] { "Category", "User", "Times" }
                               ).ToListAsync();

        return new PaginatedList<InterviewModel>
            (
                items: mapper.Map<List<InterviewModel>>(interviews),
                count: count,
                pageNumber: paginatedRequestModel.Page,
                pageSize: paginatedRequestModel.PageSize
            );
    }

    private async Task<PaginatedList<InterviewModel>> GetWithoutSearch(FilteredRequestModel paginatedRequestModel)
    {
        int count = await interviewRespository.GetCountAsync();

        List<Interview> interviews = await interviewRespository.GetAllByIncPage(
             paginatedRequestModel.Page,
                paginatedRequestModel.PageSize,
                       query => query.OrderByField(paginatedRequestModel.FieldName, paginatedRequestModel.IsAsc),
                           new string[] { "Category", "User", "Times" }
                               ).ToListAsync();

        return new PaginatedList<InterviewModel>
            (
                items: mapper.Map<List<InterviewModel>>(interviews),
                count: count,
                pageNumber: paginatedRequestModel.Page,
                pageSize: paginatedRequestModel.PageSize
            );
    }
}

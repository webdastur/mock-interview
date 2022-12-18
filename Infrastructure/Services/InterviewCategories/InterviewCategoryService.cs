using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.InterviewCategory;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.InterviewCategories;

public class InterviewCategoryService : IInterviewCategoryService
{
    private readonly IRepository<InterviewCategory> categoryRepository;
    private readonly IMapper mapper;

    public InterviewCategoryService(IRepository<InterviewCategory> categoryRepository, IMapper mapper)
    {
        this.categoryRepository = categoryRepository;
        this.mapper = mapper;
    }
    public InterviewCategoryModel CreateInterviewCategory(InterviewCategoryCreateModel interviewCategory)
    {
        var mappingModel = mapper.Map<InterviewCategory>(interviewCategory);

        categoryRepository.Add(mappingModel);

        return mapper.Map<InterviewCategoryModel>(mappingModel);
    }

    public async Task<PaginatedList<InterviewCategoryModel>> GetInterviewCategories(PaginatedRequestModel paginatedRequestModel)
    {
        int count = await categoryRepository.GetCountAsync();

        List<InterviewCategory> categories = await categoryRepository.GetAllByOrderPage(
            paginatedRequestModel.Page,
                paginatedRequestModel.PageSize,
                   query => query.OrderByDescending(order => order.UpdatedAt))
                           .ToListAsync();

        var interviewCategoryModels = mapper.Map<List<InterviewCategoryModel>>(categories);

        return new PaginatedList<InterviewCategoryModel>
            (
                items: interviewCategoryModels,
                count: count,
                pageNumber: paginatedRequestModel.Page,
                pageSize: paginatedRequestModel.PageSize
            );
    }
}

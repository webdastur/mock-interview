using Application.Common.Model;

namespace Application.Services.InterviewCategory;

public interface IInterviewCategoryService
{
    Task<PaginatedList<InterviewCategoryModel>> GetInterviewCategories(PaginatedRequestModel paginatedRequestModel);
    InterviewCategoryModel CreateInterviewCategory(InterviewCategoryCreateModel interviewCategory);
}

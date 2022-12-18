using Application.Common.Model;

namespace Application.Services.Interviews;

public interface IInterviewService
{
    Task<PaginatedList<InterviewModel>> GetAllInterviews(PaginatedRequestModel paginatedRequestModel);
    InterviewModel CreateInterview(InterviewCreateModel interviewModel);
}

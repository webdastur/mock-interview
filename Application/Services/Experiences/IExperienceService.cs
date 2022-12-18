using Application.Common.Model;

namespace Application.Services.Experiences;

public interface IExperienceService
{
    Task<PaginatedList<ExperienceModel>> GetExperiences(PaginatedRequestModel paginatedRequestModel);
    ExperienceModel CreateExperience(ExperienceCreateModel experience);
}

using Application.Common.Model;

namespace Application.Services.Projects;

public interface IProjectService
{
    ProjectModel Create(ProjectCreateModel projectCreateModel);
    ValueTask<ProjectModel> GetProjectById(int projectId);
    ValueTask<PaginatedList<ProjectModel>> GetPaginatedList(PaginatedRequestModel paginatedRequestModel);
}

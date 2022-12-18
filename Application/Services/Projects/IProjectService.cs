using Application.Common.Model;
using Application.Services.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Projects
{
    public interface IProjectService
    {
        ProjectModel Create(ProjectCreateModel projectCreateModel);
        ValueTask<ProjectModel> GetProjectById(int projectId);
        ValueTask<PaginatedList<ProjectModel>> GetPaginatedList(PaginatedRequestModel paginatedRequestModel);
    }
}

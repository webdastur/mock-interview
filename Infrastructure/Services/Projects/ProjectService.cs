using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.Projects;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUser;

        public ProjectService(
            IRepository<Project> projectRepository,
            IMapper mapper,
            ICurrentUser currentUser)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
            this.currentUser = currentUser;
        }

        public ProjectModel Create(ProjectCreateModel projectCreateModel)
        {
            Project mappedProject = mapper.Map<Project>(projectCreateModel);
            mappedProject.UserId = currentUser.GetUserId();
            projectRepository.Add(mappedProject);

            return mapper.Map<ProjectModel>(mappedProject);
        }

        public async ValueTask<PaginatedList<ProjectModel>> GetPaginatedList(PaginatedRequestModel paginatedRequestModel)
        {
            int allProjectsCount = await projectRepository.GetCountAsync();
            IList<Project> projects = await projectRepository.GetAllByExpIncPage(
                paginatedRequestModel.Page,
                    paginatedRequestModel.PageSize,
                        query => query.UserId.Equals(currentUser.GetUserId()),
                            query => query.OrderBy(order => order.Id),
                                new string[] { "Image" }
                                    ).ToListAsync();

            return new PaginatedList<ProjectModel>
                (
                    items: mapper.Map<List<ProjectModel>>(projects),
                    count: allProjectsCount,
                    pageNumber: paginatedRequestModel.Page,
                    pageSize: paginatedRequestModel.PageSize
                );
        }

        public async ValueTask<ProjectModel> GetProjectById(int projectId)
        {
            Project projectEntity = await projectRepository.GetByIdAsync(projectId);

            if (projectEntity is null)
                throw new Exception("project not found");

            return mapper.Map<ProjectModel>(projectEntity);
        }
    }
}

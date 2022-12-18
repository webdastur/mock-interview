using Application.Common.Interfaces;
using Application.Common.Model;
using Application.Services.Levels;
using Application.Services.Projects;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> projectRepository;
        private readonly IMapper mapper;

        public ProjectService(IRepository<Project> projectRepository, IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }
        public ProjectModel Create(ProjectCreateModel projectCreateModel)
        {
            Project mappedProject = mapper.Map<Project>(projectCreateModel);
            projectRepository.Add(mappedProject);
            return mapper.Map<ProjectModel>(mappedProject);
        }

        public async ValueTask<PaginatedList<ProjectModel>> GetPaginatedList(PaginatedRequestModel paginatedRequestModel)
        {
            int allProjectsCount = await projectRepository.GetCountAsync();
            IList<Project> projects = await projectRepository.GetAllByOrderPage(
                paginatedRequestModel.Page,
                    paginatedRequestModel.PageSize,
                        query => query.OrderBy(order => order.Id)
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

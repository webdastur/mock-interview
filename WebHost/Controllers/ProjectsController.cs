using Application.Common.Model;
using Application.Services.Levels;
using Application.Services.Projects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {
        private readonly IProjectService projectService;

        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        /// <summary>
        /// Create New Project
        /// </summary>
        /// <remarks>
        /// Request Example:
        /// 
        ///     Post /projects
        ///     {
        ///       "name": "string"
        ///       "description": "string"
        ///       "url": "string"
        ///       "imageId": "0"
        ///       "userId": "0"
        ///     }
        /// </remarks>
        /// <param name="projectCreateModel"></param>
        [HttpPost]

        public IActionResult PostProject(ProjectCreateModel projectCreateModel)
        {
            try
            {
                ProjectModel projectModel = projectService.Create(projectCreateModel);
                return Ok(new ResponseModel(projectModel));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        /// <summary>
        /// Get Project by id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetProject(int projectId)
        {
            try
            {
                ProjectModel projectModel = await projectService.GetProjectById(projectId);
                return Ok(new ResponseModel(projectModel));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        /// <summary>
        /// Get Project list with pagination
        /// </summary>
        /// <param name="paginatedRequestModel"></param>
        /// <returns></returns>
        [HttpGet("list")]

        public async ValueTask<IActionResult> GetProjectsList([FromQuery] PaginatedRequestModel paginatedRequestModel)
        {
            PaginatedList<ProjectModel> paginatedProjects = await projectService.GetPaginatedList(paginatedRequestModel);
            return Ok(paginatedProjects);
        }
    }
}

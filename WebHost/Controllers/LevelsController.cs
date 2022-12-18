using Application.Common.Model;
using Application.Services.Levels;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : BaseController
    {
        private readonly ILevelService levelService;

        public LevelsController(ILevelService levelService)
        {
            this.levelService = levelService;
        }

        /// <summary>
        /// Create New Level
        /// </summary>
        /// <remarks>
        /// Response Example:
        /// 
        ///     Post /levels
        ///     {
        ///       "name": "string"
        ///     }
        /// </remarks>
        /// <param name="createLevelModel"></param>
        
        [HttpPost]
        public IActionResult PostLevel(CreateLevelModel createLevelModel)
        {
            try
            {
                LevelModel levelModel = levelService.CreateLevel(createLevelModel);
                return Ok(levelModel);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetLevelById(int levelId)
        {
            LevelModel levelModel = await levelService.GetById(levelId);
            return Ok(levelModel);
        }

        [HttpDelete]
        public async ValueTask DeleteLevel(int levelId)
        {
            await levelService.DeleteLevel(levelId);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateLevel(UpdateLevelModel updateLevelModel)
        {
            LevelModel levelModel = await levelService.UpdateLevel(updateLevelModel);
            return Ok(levelModel);
        }

        [HttpGet("list")]
        public async ValueTask<IActionResult> GetLevelsByPagination(int page, int pageSize)
        {
            var paginatedLevels = await levelService.GetPaginatedList(new PaginatedRequestModel { Page = page, PageSize = pageSize });
            return Ok(paginatedLevels);
        }

    }
}

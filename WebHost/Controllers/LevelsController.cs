using Application.Common.Model;
using Application.Services.Levels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

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
        /// Request Example:
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
                return Ok(new ResponseModel(levelModel));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetLevelById(int levelId)
        {
            try
            {
                LevelModel levelModel = await levelService.GetById(levelId);
                return Ok(new ResponseModel(levelModel));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteLevel(int levelId)
        {
            try
            {
                await levelService.DeleteLevel(levelId);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateLevel(UpdateLevelModel updateLevelModel)
        {
            try
            {
                LevelModel levelModel = await levelService.UpdateLevel(updateLevelModel);
                return Ok(new ResponseModel(levelModel));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));

            }
        }

        [HttpGet("list")]
        public async ValueTask<IActionResult> GetLevelsByPagination([FromQuery] PaginatedRequestModel paginatedRequestModel)
        {
            try
            {
                PaginatedList<LevelModel> paginatedLevels = await levelService.GetPaginatedList(paginatedRequestModel);
                return Ok(new ResponseModel(paginatedLevels));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }
    }
}

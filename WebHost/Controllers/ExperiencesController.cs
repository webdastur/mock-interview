using Application.Common.Model;
using Application.Services.Experiences;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    public class ExperiencesController : BaseController
    {
        private readonly IExperienceService experienceService;

        public ExperiencesController(IExperienceService experienceService)
        {
            this.experienceService = experienceService;
        }

        /// <summary>
        /// Post New Experience
        /// </summary>
        /// <remarks>
        /// Response Example:
        /// 
        ///     Post /Experiences
        ///     {
        ///       "name": "string",
        ///       "description": "string",
        ///       "level_id": 0,
        ///       "from": "2022-12-18T12:12:55.635Z",
        ///       "to": "2022-12-18T12:12:55.635Z"
        ///     }
        /// </remarks>
        /// <param name="experienceCreateModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostExperience(ExperienceCreateModel experienceCreateModel)
        {
            try
            {
                ExperienceModel newExperience = experienceService.CreateExperience(experienceCreateModel);

                return Ok(new ResponseModel(newExperience));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        /// <summary>
        /// Get User Experiences
        /// </summary>
        /// <param name="paginatedRequestModel"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetExperiences([FromQuery]PaginatedRequestModel paginatedRequestModel)
        {
            try
            {
                PaginatedList<ExperienceModel> experiences = await experienceService.GetExperiences(paginatedRequestModel);
                return Ok(new ResponseModel(experiences));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }
    }
}

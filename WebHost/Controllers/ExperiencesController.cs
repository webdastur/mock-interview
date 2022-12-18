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

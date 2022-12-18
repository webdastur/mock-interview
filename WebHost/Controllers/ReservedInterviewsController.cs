using Application.Common.Model;
using Application.Services.Interviews;
using Application.Services.ReservedInterviews;
using Infrastructure.Services.Interviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservedInterviewsController : BaseController
    {
        private readonly IReservedInterviewService reservedInterviewService;

        public ReservedInterviewsController(IReservedInterviewService reservedInterviewService)
        {
            this.reservedInterviewService = reservedInterviewService;
        }

        /// <summary>
        /// Reserve an interview
        /// </summary>
        /// <remarks>
        /// /// Request Example:
        /// 
        ///     Post /projects
        ///     {
        ///       "interviewId": "0"
        ///       "user_id": "0"
        ///       "start_time": "datetime"
        ///       "end_time": "datetime"
        ///     }
        /// </remarks>
        /// <param name="reservedInterviewCreateModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostReservedInterview(ReservedInterviewCreateModel reservedInterviewCreateModel)
        {
            try
            {
                ReservedInterviewModel reservedInterviewModel = reservedInterviewService.Create(reservedInterviewCreateModel);
                return Ok(new ResponseModel(reservedInterviewModel));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

        /// <summary>
        /// Get User's Reserved Interviews
        /// </summary>
        /// <param name="paginatedRequestModel"></param>
        [HttpGet]
        public async Task<IActionResult> GetReservedInterviews([FromQuery] PaginatedRequestModel paginatedRequestModel)
        {
            try
            {
                PaginatedList<ReservedInterviewModel> reservedInterviews = await reservedInterviewService.GetReservedInterviews(paginatedRequestModel);

                return Ok(new ResponseModel(reservedInterviews));
            }
            catch (Exception ex)
            {
                return Ok(new ExceptionModel(ex.Message));
            }
        }

    }
}

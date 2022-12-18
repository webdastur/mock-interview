using Application.Common.Model;
using Application.Services.ReservedInterviews;
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


    }
}

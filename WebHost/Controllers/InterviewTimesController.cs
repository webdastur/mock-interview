using Application.Common.Model;
using Application.Services.Interviews;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers;

public class InterviewTimesController : BaseController
{
    private readonly IInterviewTimeService interviewTimeService;

    public InterviewTimesController(IInterviewTimeService interviewTimeService)
	{
        this.interviewTimeService = interviewTimeService;
    }

    /// <summary>
    /// Post Interview Time
    /// </summary>
    /// <param name="createTimeModel"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult PostTime(CreateTimeModel createTimeModel)
    {
        try
        {
            InterviewTimeModel interviewTimeModel = interviewTimeService.CreateInterviewTime(createTimeModel);

            return Ok(new ResponseModel(interviewTimeModel));
        }
        catch (Exception ex)
        {
            return Ok(new ExceptionModel(ex.Message));
        }
    }
}

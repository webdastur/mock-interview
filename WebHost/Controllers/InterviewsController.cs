using Application.Common.Model;
using Application.Services.Interviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers;

public class InterviewsController : BaseController
{
    private readonly IInterviewService interviewService;

    public InterviewsController(IInterviewService interviewService)
	{
        this.interviewService = interviewService;
    }


    /// <summary>
    /// Get Interviews
    /// </summary>
    /// <param name="paginatedRequestModel"></param>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetInterviews([FromQuery] PaginatedRequestModel paginatedRequestModel)
    {
        try
        {
            PaginatedList<InterviewModel> interviews = await interviewService.GetAllInterviews(paginatedRequestModel);

            return Ok(new ResponseModel(interviews));
        }
        catch (Exception ex)
        {
            return Ok(new ExceptionModel(ex.Message));
        }
    }

    /// <summary>
    /// Add new Interview
    /// </summary>
    /// <param name="interviewModel"></param>
    [HttpPost]
    public IActionResult PostInterview(InterviewCreateModel interviewModel)
    {
        try
        {
            InterviewModel newInterview = interviewService.CreateInterview(interviewModel);

            return Ok(new ResponseModel(newInterview));
        }
        catch(Exception ex) 
        {
            return Ok(new ExceptionModel(ex.Message));
        }
    }

    /// <summary>
    /// Get By filtered
    /// </summary>
    /// <param name="filteredRequestModel"></param>
    /// <returns></returns>
    [HttpGet("filter")]
    public async Task<IActionResult> GetByFilter([FromQuery]FilteredRequestModel filteredRequestModel)
    {
        try
        {
            PaginatedList<InterviewModel> interviews = await interviewService.GetByFilteredInterviews(filteredRequestModel);
            return Ok(new ResponseModel(interviews));
        }
        catch (Exception ex)
        {
            return Ok(new ExceptionModel(ex.Message));
        }
    }
}

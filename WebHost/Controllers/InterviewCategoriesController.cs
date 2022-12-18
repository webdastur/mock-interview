using Application.Common.Model;
using Application.Services.InterviewCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers;

public class InterviewCategoriesController : BaseController
{
    private readonly IInterviewCategoryService interviewCategoryService;

    public InterviewCategoriesController(IInterviewCategoryService interviewCategoryService)
    {
        this.interviewCategoryService = interviewCategoryService;
    }

    /// <summary>
    /// Get Interview Categories
    /// </summary>
    /// <param name="paginatedRequestModel"></param>
    [HttpGet]
    public async Task<IActionResult> GetCategories([FromQuery] PaginatedRequestModel paginatedRequestModel)
    {
        try
        {
            PaginatedList<InterviewCategoryModel> paginatedList = await interviewCategoryService.GetInterviewCategories(paginatedRequestModel);

            return Ok(new ResponseModel(paginatedList));
        }
        catch (Exception ex)
        {
            return Ok(new ExceptionModel(ex.Message));
        }
    }

    /// <summary>
    /// Post Interview Category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult PostCategory(InterviewCategoryCreateModel category)
    {
        try
        {
            var newCategory = interviewCategoryService.CreateInterviewCategory(category);

            return Ok(new ResponseModel(newCategory));
        }
        catch (Exception ex)
        {
            return Ok(new ExceptionModel(ex.Message));
        }
    }
}

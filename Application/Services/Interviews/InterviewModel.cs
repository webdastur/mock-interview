using Application.Common.Model;
using Application.Services.InterviewCategory;
using Application.Services.Users;

namespace Application.Services.Interviews;

public class InterviewModel : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public InterviewCategoryModel Category { get; set; }
    public UserModel User { get; set; }
}

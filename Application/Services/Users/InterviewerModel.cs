using Application.Common.Model;

namespace Application.Services.Users;

public class InterviewerModel : BaseModel
{
    public string Phone { get; set; }
    public string Role { get; set; }
    public string FullName {get;set; }
}

using Application.Common.Model;
using System.Text.Json.Serialization;

namespace Application.Services.Users;

public class InterviewerModel : BaseModel
{
    public string Phone { get; set; }
    public string Role { get; set; }

    [JsonPropertyName("full_name")]
    public string FullName {get;set; }
}

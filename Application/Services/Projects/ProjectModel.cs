using Application.Common.Model;
using Application.Services.Files;

namespace Application.Services.Projects;

public class ProjectModel : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public FileModel Image { get; set; }
}

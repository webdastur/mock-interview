using Application.Common.Model;

namespace Application.Services.Files;

public class FileModel : BaseModel
{
    public string Name { get; set; }
    public string Path { get; set; }
}

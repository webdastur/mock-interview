using Microsoft.AspNetCore.Http;

namespace Application.Services.Files;

public class FileCreateModel
{
    public IFormFile File { get; set; }
}
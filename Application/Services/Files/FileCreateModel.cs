using Microsoft.AspNetCore.Http;

namespace Application.Services.Files;

public class FileCreateModel
{
    public required IFormFile File { get; set; }
}
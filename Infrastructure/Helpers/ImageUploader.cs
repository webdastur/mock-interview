using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Helpers;

internal static class ImageUploader
{
    private static string imageUrl;
    private static string imagePath;

    public static void ImageConfigure(this IServiceCollection services, IConfiguration configuration)
    {
        imagePath = configuration["ImageSetting:Path"];
        imageUrl = configuration["ImageSetting:Url"];
    }
    public static async Task<string> UploadImage(IFormFile formFile)
    {
        ArgumentNullException.ThrowIfNull(formFile);
        string fileExt = Path.GetExtension(formFile.FileName);
        string fileName = Guid.NewGuid().ToString().Replace("-", "") + fileExt;

        if (!Directory.Exists(imagePath))
            Directory.CreateDirectory(imagePath);

        string path = Path.Combine(imagePath, fileName);

        using var fileStream = File.Open(path, FileMode.Create);
        await formFile.OpenReadStream().CopyToAsync(fileStream);

        return fileName;
    }
    public static string ImagePath() => imagePath;
    public static string ImageUrl() => imageUrl;
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Helpers;

internal static class ImageUploader
{
    private static string image_url;
    private static string image_path;

    public static void ImageConfigure(this IServiceCollection services, IConfiguration configuration)
    {
        image_path = configuration["ImageSetting:Path"];
        image_url = configuration["ImageSetting:Url"];
    }
    public static async Task<string> UploadImage(IFormFile formFile)
    {
        if (formFile == null)
            throw new ArgumentNullException(nameof(formFile));
        string fileExt = Path.GetExtension(formFile.FileName);
        string fileName = Guid.NewGuid().ToString().Replace("-", "") + fileExt;

        if (!Directory.Exists(image_path))
            Directory.CreateDirectory(image_path);

        string path = Path.Combine(image_path, fileName);

        using var fileStream = File.Open(path, FileMode.Create);
        await formFile.OpenReadStream().CopyToAsync(fileStream);

        return fileName;
    }
    public static string ImagePath() => image_path;
    public static string ImageUrl() => image_url;
}

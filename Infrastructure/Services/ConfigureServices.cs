using Application.Services.Files;
using Application.Services.InterviewCategory;
using Application.Services.Interviews;
using Application.Services.Users;
using Infrastructure.Services.Files;
using Infrastructure.Services.InterviewCategories;
using Infrastructure.Services.Interviews;
using Infrastructure.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IInterviewService, InterviewService>();
        services.AddScoped<IInterviewCategoryService, InterviewCategoryService>();

        return services;
    }
}

using Application.Services.Levels;
using Application.Services.Files;
using Application.Services.Users;
using Infrastructure.Services.Levels;
using Infrastructure.Services.Files;
using Infrastructure.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.Projects;
using Infrastructure.Services.Projects;

namespace Infrastructure.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILevelService, LevelService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ILevelService, LevelService>();
        services.AddScoped<IProjectService, ProjectService>();
        return services;
    }
}

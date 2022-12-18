using Application.Services.Levels;
using Application.Services.Users;
using Infrastructure.Services.Levels;
using Infrastructure.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILevelService, LevelService>();

        return services;
    }
}

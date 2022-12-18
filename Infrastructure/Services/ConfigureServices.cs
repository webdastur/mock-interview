using Application.Services.Users;
using Infrastructure.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}

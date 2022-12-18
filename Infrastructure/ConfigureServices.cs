using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Services;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddAuth()
            .AddPersistence()
            .AddServices();
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseCurrentUser();
        app.UsePersistence();

        return app;
    }
}

using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddAuth()
            .AddPersistence();
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseCurrentUser();
        app.UsePersistence();

        return app;
    }
}

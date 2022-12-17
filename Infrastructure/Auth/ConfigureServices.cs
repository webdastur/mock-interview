using Application.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Auth;

public static class ConfigureServices
{
    internal static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddCurrentUser();

        return services;
    }

    internal static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app) =>
        app.UseMiddleware<CurrentUserMiddleware>();

    private static IServiceCollection AddCurrentUser(this IServiceCollection services) =>
        services
            .AddScoped<CurrentUserMiddleware>()
                .AddScoped<ICurrentUser, CurrentUser>()
                    .AddScoped(sp => (ICurrenctUserInitializer)sp.GetRequiredService<ICurrentUser>());
}

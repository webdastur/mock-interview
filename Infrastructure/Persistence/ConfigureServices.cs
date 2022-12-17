using Infrastructure.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Initializer;
using Microsoft.AspNetCore.Builder;
using Application.Common.Interfaces;
using Infrastructure.Persistence.Interceptors;

namespace Infrastructure.Persistence;

internal static class ConfigureServices
{
    internal static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddOptions<DatabaseSetting>()
           .BindConfiguration(nameof(DatabaseSetting));

        services.AddDbContext<ApplicationDbContext>((p, m) =>
        {
            DatabaseSetting databaseSettings = p.GetRequiredService<IOptions<DatabaseSetting>>().Value;
            m.UseNpgsql(databaseSettings.ConnectionString);
        });

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddTransient<ApplicationDbInitializer>();

        return services;
    }

    internal static IApplicationBuilder UsePersistence(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>();
        initializer.InitializeAsync().Wait();

        return app;
    }
}

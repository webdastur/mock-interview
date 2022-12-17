using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Initializer;

internal class ApplicationDbInitializer
{
    private readonly ApplicationDbContext dbContext;

    public ApplicationDbInitializer(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        if (dbContext.Database.GetMigrations().Any())
        {
            if ((await dbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
            {
                await dbContext.Database.MigrateAsync(cancellationToken);
            }
        }
    }
}

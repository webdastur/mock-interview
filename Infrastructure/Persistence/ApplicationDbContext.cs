using Domain.Entities;
using System.Reflection;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.DefaultData;
using Infrastructure.Persistence.Interceptors;
using File = Domain.Entities.File;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly ICurrentUser currentUser;
    public ApplicationDbContext(DbContextOptions options, ICurrentUser currentUser) : base(options)
    {
        this.currentUser = currentUser;
    }

    public DbSet<Experience> Experiences => Set<Experience>();
    public DbSet<File> Files => Set<File>();
    public DbSet<Interview> Interviews => Set<Interview>();
    public DbSet<InterviewCategory> InterviewCategories => Set<InterviewCategory>();
    public DbSet<InterviewLevel> InterviewLevels => Set<InterviewLevel>();
    public DbSet<InterviewTime> InterviewTimes => Set<InterviewTime>();
    public DbSet<Level> Levels => Set<Level>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ReservedInterview> ReservedInterviews => Set<ReservedInterview>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.DefaultSuperUser();

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors(new AuditableEntitySaveChangesInterceptor(currentUser));
        base.OnConfiguring(builder);
    }
}

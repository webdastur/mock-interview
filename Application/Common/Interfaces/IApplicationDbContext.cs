using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using File = Domain.Entities.File;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Experience> Experiences { get; }
    public DbSet<File> Files { get;}
    public DbSet<Interview> Interviews { get; }
    public DbSet<InterviewCategory> InterviewCategories { get; }
    public DbSet<InterviewLevel> InterviewLevels { get; }
    public DbSet<InterviewTime> InterviewTimes { get; }
    public DbSet<Level> Levels { get; }
    public DbSet<Payment> Payments { get; }
    public DbSet<Project> Projects { get; }
    public DbSet<ReservedInterview> ReservedInterviews { get; }
    public DbSet<User> Users { get; }
}

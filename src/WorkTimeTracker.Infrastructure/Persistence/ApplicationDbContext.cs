using Microsoft.EntityFrameworkCore;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Project> Projects => Set<Project>();

    public DbSet<ProjectType> ProjectTypes => Set<ProjectType>();

    public DbSet<WorkTimeTracking> WorkTimeTrackings => Set<WorkTimeTracking>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}

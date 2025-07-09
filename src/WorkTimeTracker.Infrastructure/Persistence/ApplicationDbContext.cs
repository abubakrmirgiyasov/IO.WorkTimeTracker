using Microsoft.EntityFrameworkCore;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; }

    public DbSet<ProjectType> ProjectTypes { get; set; }

    public DbSet<WorkTimeTracking> WorkTimeTrackings { get; set; }

}

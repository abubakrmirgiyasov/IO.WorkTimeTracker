using Microsoft.EntityFrameworkCore;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Project> Projects => Set<Project>();

    public DbSet<ProjectType> ProjectTypes => Set<ProjectType>();

    public DbSet<WorkTimeTracking> WorkTimeTrackings => Set<WorkTimeTracking>();

    public DbSet<ProjectWithProjectTypeRelation> ProjectdWithProjectTypes => Set<ProjectWithProjectTypeRelation>();

    public DbSet<User> Users => Set<User>();

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<UserPermissionRelation> UserPermissions => Set<UserPermissionRelation>();

    public DbSet<Image> Images => Set<Image>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}

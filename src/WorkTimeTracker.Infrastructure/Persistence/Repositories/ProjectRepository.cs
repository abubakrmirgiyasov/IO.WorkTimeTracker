using Ardalis.Specification.EntityFrameworkCore;
using WorkTimeTracker.Application.Projects.Repositories;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Infrastructure.Persistence.Repositories;

internal sealed class ProjectRepository : RepositoryBase<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}

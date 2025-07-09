using Ardalis.Specification.EntityFrameworkCore;
using WorkTimeTracker.Application.ProjectTypes.Repositories;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Infrastructure.Persistence.Repositories;

internal sealed class ProjectTypeRepository : RepositoryBase<ProjectType>, IProjectTypeRepository
{
    public ProjectTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

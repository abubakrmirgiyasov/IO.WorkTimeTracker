using Ardalis.Specification.EntityFrameworkCore;
using WorkTimeTracker.Application.WorkTimeTrackings.Repositories;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Infrastructure.Persistence.Repositories;

internal sealed class WorkTimeTrackingRepository : RepositoryBase<WorkTimeTracking>, IWorkTimeTrackingRepository
{
    public WorkTimeTrackingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}

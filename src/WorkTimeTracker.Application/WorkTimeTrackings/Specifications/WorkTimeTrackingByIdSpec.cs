using Ardalis.Specification;
using WorkTimeTracker.Application.Common.Specifications;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.WorkTimeTrackings.Specifications;

public sealed class WorkTimeTrackingByIdSpec : DbSpecifications<WorkTimeTracking>
{
    public long Id { get; }

    public WorkTimeTrackingByIdSpec(long id, bool asNoTracking = false)
    {
        Id = id;

        if (asNoTracking)
            Query.AsNoTracking();

        Query.Where(x => x.Id == Id);
    }
}

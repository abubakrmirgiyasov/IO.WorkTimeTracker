using Ardalis.Specification;
using WorkTimeTracker.Application.Common.Specifications;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.ProjectTypes.Specifications;

public sealed class ProjectTypeByIdSpec : DbSpecifications<ProjectType>
{
    public long ProjectTypeId { get; }

    public ProjectTypeByIdSpec(long projectTypeId, bool asNoTracking = false)
    {
        ProjectTypeId = projectTypeId;

        if (asNoTracking)
            Query.AsNoTracking();

        Query.Where(x => x.Id == projectTypeId);
    }
}

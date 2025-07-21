using Ardalis.Specification;
using WorkTimeTracker.Application.Common.Specifications;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.Projects.Specifications;

public sealed class ProjectByIdSpec : DbSpecifications<Project>
{
    public long ProjectId { get; }

    public ProjectByIdSpec(long projectId, bool asNoTracking = false)
    {
        ProjectId = projectId;

        if (asNoTracking)
            Query.AsNoTracking();

        Query.Where(x => x.Id == projectId);
    }
}

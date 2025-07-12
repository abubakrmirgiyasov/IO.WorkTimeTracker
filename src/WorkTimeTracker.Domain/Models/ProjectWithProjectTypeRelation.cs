namespace WorkTimeTracker.Domain.Models;

public class ProjectWithProjectTypeRelation
{
    public required long ProjectId { get; set; }
    public Project Project { get; set; } = default!;

    public required long ProjectTypeId { get; set; }
    public ProjectType ProjectType { get; set; } = default!;
}

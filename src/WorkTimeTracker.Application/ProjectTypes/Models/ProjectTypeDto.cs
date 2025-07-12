namespace WorkTimeTracker.Application.ProjectTypes.Models;

public sealed class ProjectTypeDto
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}

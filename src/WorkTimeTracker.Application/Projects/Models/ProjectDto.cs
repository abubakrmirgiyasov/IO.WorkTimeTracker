namespace WorkTimeTracker.Application.Projects.Models;

public class ProjectDto
{
    public long Id { get; set; }

    public string? Link { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}

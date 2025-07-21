using WorkTimeTracker.Application.ProjectTypes.Models;

namespace WorkTimeTracker.Application.WorkTimeTrackings.Models;

public sealed class WorkTimeTrackingDto
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public required string ShortDescription { get; set; }

    public required DateTime DateMin { get; set; }

    public required DateTime DateMax { get; set; }

    public required DateTime Time { get; set; }

    public required ProjectTypeDto ProjectType { get; set; }
}

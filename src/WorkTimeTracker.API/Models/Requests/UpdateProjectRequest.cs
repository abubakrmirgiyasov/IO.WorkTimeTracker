namespace WorkTimeTracker.API.Models.Requests;

public sealed class UpdateProjectRequest
{
    public string? Link { get; init; }

    public required string Name { get; init; }

    public string? Description { get; init; }
}

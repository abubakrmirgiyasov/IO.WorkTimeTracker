namespace WorkTimeTracker.API.Models.Requests;

public sealed class UpdateWorkTimeTrackingRequest
{

    public required string Name { get; init; }

    public string? Description { get; init; }

    public required string ShortDescription { get; init; }

    public required DateTime DateMin { get; init; }

    public required DateTime DateMax { get; init; }

    public required DateTime Time { get; init; }

    public required long ProjectTypeId { get; init; }
}

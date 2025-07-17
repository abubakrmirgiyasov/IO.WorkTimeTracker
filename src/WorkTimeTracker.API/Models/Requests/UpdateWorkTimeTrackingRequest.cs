namespace WorkTimeTracker.API.Models.Requests;

public class UpdateWorkTimeTrackingRequest
{

    public required string Name { get; set; }

    public string? Description { get; set; }

    public required string ShortDescription { get; set; }

    public required DateTime DateMin { get; set; }

    public required DateTime DateMax { get; set; }

    public required DateTime Time { get; set; }

    public required long ProjectTypeId { get; set; }
}

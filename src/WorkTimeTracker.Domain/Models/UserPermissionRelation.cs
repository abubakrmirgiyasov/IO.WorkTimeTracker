namespace WorkTimeTracker.Domain.Models;

public class UserPermissionRelation
{
    public required long UserId { get; set; }
    public User User { get; set; } = default!;

    public required long PermissionId { get; set; }
    public Permission permission { get; set; } = default!;
}

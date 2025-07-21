using WorkTimeTracker.Domain.Common;
using WorkTimeTracker.Shared.Exceptions;
using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Domain.Models;

public class Permission : Entity
{
    public string Title { get; private set; }

    public string? Description { get; private set; }

    public Permission(string title)
    {
        Title = title;
    }

    public void SetTitleSpace(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new BussinessLogicException(PermissionErrors.TitleCantBeNull);

        Title = title;
    }

    public void SetDescriptionSpace(string description)
    {
        if (!string.IsNullOrWhiteSpace(description))
            throw new BussinessLogicException(PermissionErrors.DescriptionCantBeNull);

        Description = description;
    }

    public static class PermissionErrors
    {
        public static readonly Error TitleCantBeNull = new(
            "Permission.TitleCantBeNull",
            "Название разрешения не может быть пустым"
        );

        public static readonly Error DescriptionCantBeNull = new(
            "Permission.DescriptionCantBeNull",
            "Описание не может быть пустым."
        );
    }
}


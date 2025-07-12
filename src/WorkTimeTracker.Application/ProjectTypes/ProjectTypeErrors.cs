using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Application.ProjectTypes;

public static class ProjectTypeErrors
{
    public static readonly Error NotFound = new(
        "ProjectType.NotFound",
        "Тип проекта не найден."
    );
}

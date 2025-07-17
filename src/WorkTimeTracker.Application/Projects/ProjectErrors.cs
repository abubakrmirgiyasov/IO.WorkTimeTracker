using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Application.Projects;

public static class ProjectErrors
{
    public static readonly Error NotFound = new(
        "Project.NotFound",
        "Тип проекта не найден."
    );
}

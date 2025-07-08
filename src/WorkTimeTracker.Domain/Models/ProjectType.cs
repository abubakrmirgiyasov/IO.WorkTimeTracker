using WorkTimeTracker.Domain.Common;
using WorkTimeTracker.Shared.Exceptions;
using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Domain.Models;

public class ProjectType : Entity
{
    public string Name { get; private set; }

    public string? Description { get; private set; }

    public long ProjectId { get; private set; }

    public Project Project { get; set; } = default!;

    public ProjectType(string name, long projectId)
    {
        Name = name;
        ProjectId = projectId;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(Name))
            throw new BussinessLogicException(ProjectTypeErrors.NameCantBeNull);

        Name = name;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(Description))
            throw new BussinessLogicException(ProjectTypeErrors.DescriptionCantBeNull);

        Description = description;
    }

    public void SetProjectId(long projectId)
    {
        if(projectId <= 0)
            throw new BussinessLogicException(ProjectTypeErrors.ProjectIdCantBeNull);

        ProjectId = projectId;
    }

    public static class ProjectTypeErrors
    {
        public static readonly Error NameCantBeNull = new(
            "WorkTimeTracking.NameCantBeNull",
            "Название не может быть пустым."
        );

        public static readonly Error DescriptionCantBeNull = new(
           "WorkTimeTracking.DescriptionCantBeNull",
           "Описание не может быть пустым."
        );

        public static readonly Error ProjectIdCantBeNull = new(
             "WorkTimeTracking.ProjectIdCantBeNull",
            "Тип проекта не может быть пустым."
        );
    }
}

using WorkTimeTracker.Domain.Common;
using WorkTimeTracker.Shared.Exceptions;
using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Domain.Models;

public class ProjectType : Entity
{
    public string Name { get; private set; }

    public string? Description { get; private set; }

    public List<ProjectWithProjectTypeRelation> ProjectTypeRelations { get; set; } = default!;

    public ProjectType(string name)
    {
        Name = name;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new BussinessLogicException(ProjectTypeErrors.NameCantBeNull);

        Name = name;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
            throw new BussinessLogicException(ProjectTypeErrors.DescriptionCantBeNull);

        Description = description;
    }

    public static class ProjectTypeErrors
    {
        public static readonly Error NameCantBeNull = new(
            "ProjectType.NameCantBeNull",
            "Название не может быть пустым."
        );

        public static readonly Error DescriptionCantBeNull = new(
           "ProjectType.DescriptionCantBeNull",
           "Описание не может быть пустым."
        );
    }
}

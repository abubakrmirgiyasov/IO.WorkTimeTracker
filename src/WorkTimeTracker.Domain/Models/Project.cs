using WorkTimeTracker.Domain.Common;
using WorkTimeTracker.Shared.Exceptions;
using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Domain.Models;

public class Project : Entity
{
    public string? Link { get; private set; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public int ProjectId { get; private set; }

    public Project(string name, int prolectId)
    {
        Name = name;
        ProjectId = prolectId;
    }

    public void SetLink(string link)
    {
        if (string.IsNullOrWhiteSpace(link))
            throw new BussinessLogicException(ProjectErrors.LinkCantBeNull);

        Link = link;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new BussinessLogicException(ProjectErrors.NameCantBeNull);

        Name = name;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new BussinessLogicException(ProjectErrors.DescriptionCantBeNull);

        Description = description;
    }

    public void SetProjectId(int projectId)
    {
        if (projectId <= 0)
            throw new BussinessLogicException(ProjectErrors.ProjectIdCantBeNull);

        ProjectId = projectId;
    }

    public static class ProjectErrors
    {
        public static readonly Error LinkCantBeNull = new(
           "Project.NameCantBeNull",
           "Название не может быть пустым."
        );

        public static readonly Error NameCantBeNull = new(
            "Project.NameCantBeNull",
            "Название не может быть пустым."
        );

        public static readonly Error DescriptionCantBeNull = new(
           "Project.DescriptionCantBeNull",
           "Описание не может быть пустым."
        );

        public static readonly Error ProjectIdCantBeNull = new(
           "Project.ProjectIdCantBeNull",
          "Тип проекта не может быть пустым."
        );
    }
}

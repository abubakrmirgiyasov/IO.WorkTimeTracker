using WorkTimeTracker.Domain.Common;
using WorkTimeTracker.Shared.Exceptions;
using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Domain.Models;

public class WorkTimeTracking : Entity
{
    public string Name { get; private set; }

    public string? Description { get; private set; }

    public string ShortDescription { get; private set; }

    public DateTime DateMin { get; private set; }

    public DateTime DateMax { get; private set; }

    public DateTime Time { get; private set; }

    public long ProjectTypeId { get; private set; }

    public ProjectType ProjectType { get; set; } = default!;

    public WorkTimeTracking(string name, string shortDescription, long projectTypeId)
    {
        Name = name;
        ShortDescription = shortDescription;
        ProjectTypeId = projectTypeId;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new BussinessLogicException(WorkTimeTrackingErrors.NameCantBeNull);

        Name = name;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(Description))
            throw new BussinessLogicException(WorkTimeTrackingErrors.DescriptionCantBeNull);

        Description = description;
    }

    public void SetShortDescription(string shortDescription)
    {
        if (string.IsNullOrEmpty(shortDescription))
            throw new BussinessLogicException(WorkTimeTrackingErrors.ShortDescriptionCantBeNull);

        ShortDescription  = shortDescription;
    }

    public void SetDateMin(DateTime dateMin)
    {
        if(DateTime.MinValue == dateMin)
            throw new BussinessLogicException(WorkTimeTrackingErrors.DateMinCantBeNull);

        DateMin = dateMin;
    }

    public void SetDateMax(DateTime dateMax)
    {
        if (dateMax >= DateTime.MinValue)
            throw new BussinessLogicException(WorkTimeTrackingErrors.DateMaxCantBeNull);

        DateMax = dateMax;
    }

    public void SetTime(DateTime time)
    {
        if (time == DateTime.MinValue)
            throw new BussinessLogicException(WorkTimeTrackingErrors.TimeCantBeNull);

        Time = time;
    }

    public void SetProjectTypeId(long projectTypeId)
    {
        if (projectTypeId <= 0)
            throw new BussinessLogicException(WorkTimeTrackingErrors.ProjectTypeIdCantBeNull);

        ProjectTypeId = projectTypeId;
    }

    public static class WorkTimeTrackingErrors
    {
        public static readonly Error NameCantBeNull = new(
            "WorkTimeTracking.NameCantBeNull",
            "Название не может быть пустым."
        );

        public static readonly Error DescriptionCantBeNull = new(
            "WorkTimeTracking.DescriptionCantBeNull",
            "Описание не может быть пустым."
        );

        public static readonly Error ShortDescriptionCantBeNull = new(
            "WorkTimeTracking.ShortDescriptionCantBeNull",
            "Краткое описание не может быть пустым."
        );

        public static readonly Error DateMinCantBeNull = new(
             "WorkTimeTracking.DateMinCantBeNull",
             "Минимальная дата не может быть пустой."
         );

        public static readonly Error DateMaxCantBeNull = new(
             "WorkTimeTracking.DateMaxCantBeNull",
             "Максимальная дата не может быть пустой."
         );

        public static readonly Error TimeCantBeNull = new(
             "WorkTimeTracking.TimeCantBeNull",
             "Время не может быть пустым."
         );

        public static readonly Error ProjectTypeIdCantBeNull = new(
            "WorkTimeTracking.ProjectTypeIdCantBeNull",
            "Тип проекта не может быть пустым."
        );
    }
}

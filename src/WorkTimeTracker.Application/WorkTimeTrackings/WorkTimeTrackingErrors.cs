using WorkTimeTracker.Shared.Models;

namespace WorkTimeTracker.Application.WorkTimeTrackings;
public static class WorkTimeTrackingErrors
{
    public static readonly Error NotFound = new(
        "WorkTimeTracking.NotFound",
        "Учёт рабочего времени не найден."
    );
}

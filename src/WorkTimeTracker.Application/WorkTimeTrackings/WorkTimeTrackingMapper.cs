using AutoMapper;
using WorkTimeTracker.Application.WorkTimeTrackings.Models;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.WorkTimeTrackings;
public sealed class WorkTimeTrackingMapper : Profile
{
    public WorkTimeTrackingMapper()
    {
        CreateMap<WorkTimeTracking, WorkTimeTrackingDto>();
    }
}

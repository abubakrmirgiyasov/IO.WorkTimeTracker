using AutoMapper;
using WorkTimeTracker.Application.ProjectTypes.Models;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.ProjectTypes;

public sealed class ProjectTypeMapper : Profile
{
    public ProjectTypeMapper()
    {
        CreateMap<ProjectType, ProjectTypeDto>();
    }
}

using AutoMapper;
using WorkTimeTracker.Application.Projects.Models;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.Projects;

public sealed class ProjectMapper : Profile
{
    public ProjectMapper()
    {
        CreateMap<Project, ProjectDto>();
    }
}

using Ardalis.Specification;
using AutoMapper;
using MediatR;
using WorkTimeTracker.Application.Common.Specifications;
using WorkTimeTracker.Application.Projects.Models;
using WorkTimeTracker.Application.Projects.Repositories;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.Projects.Queries;

public sealed record GetProjects : IRequest<List<ProjectDto>>;

internal sealed class GetProjectsHandler : IRequestHandler<GetProjects, List<ProjectDto>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public GetProjectsHandler(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<List<ProjectDto>> Handle(GetProjects request, CancellationToken cancellationToken)
    {
        var spec = new DbSpecifications<Project>();
        spec.Query.AsNoTracking();

        var projects = await _projectRepository.ListAsync(spec, cancellationToken);

        return _mapper.Map<List<ProjectDto>>(projects);
    }
}

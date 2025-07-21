using AutoMapper;
using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.Projects.Models;
using WorkTimeTracker.Application.Projects.Repositories;
using WorkTimeTracker.Application.Projects.Specifications;
using WorkTimeTracker.Shared.Exceptions;

namespace WorkTimeTracker.Application.Projects.Queries;

public sealed record GetProjectById(long ProjectId) : IRequest<ProjectDto>;

public sealed class GetProjectByIdValidator : AbstractValidator<GetProjectById>
{
    public GetProjectByIdValidator()
    {
        RuleFor(x => x.ProjectId).GreaterThan(0);
    }
}

internal sealed class GetProjectByIdHandler : IRequestHandler<GetProjectById, ProjectDto>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public GetProjectByIdHandler(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<ProjectDto> Handle(GetProjectById request, CancellationToken cancellationToken = default)
    {
        var spec = new ProjectByIdSpec(request.ProjectId, asNoTracking: true);
        var project = await _projectRepository.FirstOrDefaultAsync(spec, cancellationToken);

        if (project is null)
            throw new ResourceNotFoundException(ProjectErrors.NotFound);

        return _mapper.Map<ProjectDto>(project);
    }
}

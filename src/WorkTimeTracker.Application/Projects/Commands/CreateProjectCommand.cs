using AutoMapper;
using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.Projects.Models;
using WorkTimeTracker.Application.Projects.Repositories;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.Projects.Commands;

public sealed record CreateProjectCommand(
    string Name,
    string? Description,
    string? Link
) : IRequest<ProjectDto>;

public sealed class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Link)
            .NotEmpty()
            .When(x => !string.IsNullOrWhiteSpace(x.Link));
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Description)
            .NotEmpty()
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}

internal sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    private readonly TimeProvider _timeProvider;

    public CreateProjectCommandHandler(
        IProjectRepository projectRepository,
        IMapper mapper,
        TimeProvider timeProvider)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
        _timeProvider = timeProvider;
    }

    public async Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        // TODO
        var project = new Project(request.Name)
        {
            CreatedDate = _timeProvider.GetLocalNow().DateTime,
            CreatedBy = 1
        };

        if (!string.IsNullOrWhiteSpace(request.Link))
            project.SetLink(request.Link);

        if (!string.IsNullOrWhiteSpace(request.Description))
            project.SetDescription(request.Description);

        await _projectRepository.AddAsync(project, cancellationToken);
        await _projectRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProjectDto>(project);
    }
}

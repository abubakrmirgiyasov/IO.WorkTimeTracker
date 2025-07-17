using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.Projects.Repositories;
using WorkTimeTracker.Application.Projects.Specifications;
using WorkTimeTracker.Shared.Exceptions;

namespace WorkTimeTracker.Application.Projects.Commands;

public sealed record UpdateProjectCommand(
    long Id,
    string? Link,
    string Name,
    string? Description
) : IRequest;

public sealed class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(x => x.Link)
          .NotEmpty()
          .When(x => !string.IsNullOrEmpty(x.Link));

        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty()
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}

internal sealed class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IProjectRepository _projectRepository;
    private readonly TimeProvider _timeProvider;

    public UpdateProjectCommandHandler(
        IProjectRepository projectTypeRepository,
        TimeProvider timeProvider)
    {
        _projectRepository = projectTypeRepository;
        _timeProvider = timeProvider;
    }

    public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.FirstOrDefaultAsync(
            new ProjectByIdSpec(request.Id),
            cancellationToken
        );

        if (project is null)
            throw new ResourceNotFoundException(ProjectErrors.NotFound);

        if (!string.IsNullOrEmpty(request.Link))
            project.SetLink(request.Link);

        project.SetName(request.Name);

        if (!string.IsNullOrEmpty(request.Description))
            project.SetDescription(request.Description);

        // TODO
        project.UpdatedDate = _timeProvider.GetLocalNow().DateTime;
        project.UpdatedBy = 1;

        await _projectRepository.UpdateAsync(project, cancellationToken);
        await _projectRepository.SaveChangesAsync(cancellationToken);
    }
}

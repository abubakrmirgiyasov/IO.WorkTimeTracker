using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.ProjectTypes.Repositories;
using WorkTimeTracker.Application.ProjectTypes.Specifications;
using WorkTimeTracker.Shared.Exceptions;

namespace WorkTimeTracker.Application.ProjectTypes.Commands;

public sealed record UpdateProjectTypeCommand(
    long ProjectTypeId,
    string Name,
    string? Description
) : IRequest;

public sealed class UpdateProjectTypeCommandValidator : AbstractValidator<UpdateProjectTypeCommand>
{
    public UpdateProjectTypeCommandValidator()
    {
        RuleFor(x => x.ProjectTypeId).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty()
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}

internal sealed class UpdateProjectTypeCommandHandler : IRequestHandler<UpdateProjectTypeCommand>
{
    private readonly IProjectTypeRepository _projectTypeRepository;
    private readonly TimeProvider _timeProvider;

    public UpdateProjectTypeCommandHandler(
        IProjectTypeRepository projectTypeRepository,
        TimeProvider timeProvider)
    {
        _projectTypeRepository = projectTypeRepository;
        _timeProvider = timeProvider;
    }

    public async Task Handle(UpdateProjectTypeCommand request, CancellationToken cancellationToken)
    {
        var projectType = await _projectTypeRepository.FirstOrDefaultAsync(
            new ProjectTypeByIdSpec(request.ProjectTypeId),
            cancellationToken
        );

        if (projectType is null)
            throw new ResourceNotFoundException(ProjectTypeErrors.NotFound);

        projectType.SetName(request.Name);

        if (!string.IsNullOrEmpty(request.Description))
            projectType.SetDescription(request.Description);

        // TODO
        projectType.UpdatedDate = _timeProvider.GetLocalNow().DateTime;
        projectType.UpdatedBy = 1;

        await _projectTypeRepository.UpdateAsync(projectType, cancellationToken);
        await _projectTypeRepository.SaveChangesAsync(cancellationToken);
    }
}

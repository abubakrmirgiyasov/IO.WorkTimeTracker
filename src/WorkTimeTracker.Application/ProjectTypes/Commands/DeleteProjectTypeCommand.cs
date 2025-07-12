using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.ProjectTypes.Repositories;
using WorkTimeTracker.Application.ProjectTypes.Specifications;
using WorkTimeTracker.Shared.Exceptions;

namespace WorkTimeTracker.Application.ProjectTypes.Commands;

public sealed record DeleteProjectTypeCommand(long ProjectTypeId) : IRequest;

public sealed class DeleteProjectTypeCommandValidator : AbstractValidator<DeleteProjectTypeCommand>
{
    public DeleteProjectTypeCommandValidator()
    {
        RuleFor(x => x.ProjectTypeId).GreaterThan(0);
    }
}

internal sealed class DeleteProjectTypeCommandHandler : IRequestHandler<DeleteProjectTypeCommand>
{
    private readonly IProjectTypeRepository _projectTypeRepository;

    public DeleteProjectTypeCommandHandler(IProjectTypeRepository projectTypeRepository)
    {
        _projectTypeRepository = projectTypeRepository;
    }

    public async Task Handle(DeleteProjectTypeCommand request, CancellationToken cancellationToken)
    {
        var projectType = await _projectTypeRepository.FirstOrDefaultAsync(
            new ProjectTypeByIdSpec(request.ProjectTypeId),
            cancellationToken
        );

        if (projectType is null)
            throw new ResourceNotFoundException(ProjectTypeErrors.NotFound);

        await _projectTypeRepository.DeleteAsync(projectType, cancellationToken);
        await _projectTypeRepository.SaveChangesAsync(cancellationToken);
    }
}

using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.Projects.Repositories;
using WorkTimeTracker.Application.Projects.Specifications;
using WorkTimeTracker.Shared.Exceptions;

namespace WorkTimeTracker.Application.Projects.Commands;

public sealed record DeleteProjectCommand(long Id) : IRequest;

public sealed class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}
internal sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.FirstOrDefaultAsync(
            new ProjectByIdSpec(request.Id),
            cancellationToken
        );

        if (project is null)
            throw new ResourceNotFoundException(ProjectErrors.NotFound);

        await _projectRepository.DeleteAsync(project, cancellationToken);
        await _projectRepository.SaveChangesAsync(cancellationToken);
    }
}

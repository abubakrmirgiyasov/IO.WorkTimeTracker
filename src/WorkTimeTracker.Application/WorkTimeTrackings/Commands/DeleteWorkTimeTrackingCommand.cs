using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.WorkTimeTrackings.Repositories;
using WorkTimeTracker.Application.WorkTimeTrackings.Specifications;
using WorkTimeTracker.Shared.Exceptions;

namespace WorkTimeTracker.Application.WorkTimeTrackings.Commands;

public sealed record DeleteWorkTimeTrackingCommand(long WorkTimeTrackingId) : IRequest;

public sealed class DeleteWorkTimeTrackingCommandValidator : AbstractValidator<DeleteWorkTimeTrackingCommand>
{
    public DeleteWorkTimeTrackingCommandValidator()
    {
        RuleFor(x => x.WorkTimeTrackingId).GreaterThan(0);
    }
}

internal sealed class DeleteWorkTimeTrackingCommandHandler : IRequestHandler<DeleteWorkTimeTrackingCommand>
{
    private readonly IWorkTimeTrackingRepository _workTimeTrackingRepository;

    public DeleteWorkTimeTrackingCommandHandler(IWorkTimeTrackingRepository workTimeTrackingRepository)
    {
        _workTimeTrackingRepository = workTimeTrackingRepository;
    }
    public async Task Handle(DeleteWorkTimeTrackingCommand request, CancellationToken cancellationToken)
    {
        var workTimeTracking = await _workTimeTrackingRepository.FirstOrDefaultAsync(
            new WorkTimeTrackingByIdSpec(request.WorkTimeTrackingId),
            cancellationToken
        );

        if (workTimeTracking is null)
            throw new ResourceNotFoundException(WorkTimeTrackingErrors.NotFound);

        await _workTimeTrackingRepository.DeleteAsync(workTimeTracking, cancellationToken);
        await _workTimeTrackingRepository.SaveChangesAsync(cancellationToken);
    }
}

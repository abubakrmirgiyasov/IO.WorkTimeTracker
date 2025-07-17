using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.WorkTimeTrackings.Repositories;
using WorkTimeTracker.Application.WorkTimeTrackings.Specifications;
using WorkTimeTracker.Shared.Exceptions;

namespace WorkTimeTracker.Application.WorkTimeTrackings.Commands;

public sealed record UpdateWorkTimeTrackingCommand(
    long WorkTimeTrackingId,
    string Name,
    string? Description,
    string ShortDescription,
    DateTime DateMin,
    DateTime DateMax,
    DateTime Time,
    long ProjectTypeId
) : IRequest;

public sealed class UpdateWorkTimeTrackingCommandValidator : AbstractValidator<UpdateWorkTimeTrackingCommand>
{
    public UpdateWorkTimeTrackingCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ShortDescription).NotEmpty();
        RuleFor(x => x.DateMin).NotEmpty();
        RuleFor(x => x.DateMax).NotEmpty();
        RuleFor(x => x.Time).NotEmpty();
        RuleFor(x => x.ProjectTypeId).NotEmpty();
    }
}

internal sealed class UpdateWorkTimeTrackingCommandHandler : IRequestHandler<UpdateWorkTimeTrackingCommand>
{
    private readonly IWorkTimeTrackingRepository _workTimeTrackingRepository;
    private readonly TimeProvider _timeProvider;

    public UpdateWorkTimeTrackingCommandHandler(
        IWorkTimeTrackingRepository workTimeTrackingRepository,
        TimeProvider timeProvider)
    {
        _workTimeTrackingRepository = workTimeTrackingRepository;
        _timeProvider = timeProvider;
    }

    public async Task Handle(UpdateWorkTimeTrackingCommand request, CancellationToken cancellationToken)
    {
        var workTimeTracking = await _workTimeTrackingRepository.FirstOrDefaultAsync(
            new WorkTimeTrackingByIdSpec(request.WorkTimeTrackingId),
            cancellationToken
        );

        if (workTimeTracking is null)
            throw new ResourceNotFoundException(WorkTimeTrackingErrors.NotFound);

        if (!string.IsNullOrEmpty(request.Description))
            workTimeTracking.SetDescription(request.Description);

        workTimeTracking.SetName(request.Name);

        workTimeTracking.SetShortDescription(request.ShortDescription);

        workTimeTracking.SetDateMin(request.DateMin);

        workTimeTracking.SetDateMax(request.DateMax);

        workTimeTracking.SetTime(request.Time);

        workTimeTracking.SetProjectTypeId(request.ProjectTypeId);

        // TODO
        workTimeTracking.UpdatedDate = _timeProvider.GetLocalNow().DateTime;
        workTimeTracking.UpdatedBy = 1;

        await _workTimeTrackingRepository.UpdateAsync(workTimeTracking, cancellationToken);
        await _workTimeTrackingRepository.SaveChangesAsync(cancellationToken);
    }
}

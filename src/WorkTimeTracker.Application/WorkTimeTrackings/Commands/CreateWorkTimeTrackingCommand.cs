using AutoMapper;
using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.WorkTimeTrackings.Models;
using WorkTimeTracker.Application.WorkTimeTrackings.Repositories;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.WorkTimeTrackings.Commands;

public sealed record CreateWorkTimeTrackingCommand(
    string Name,
    string? Description,
    string ShortDescription,
    DateTime DateMin,
    DateTime DateMax,
    DateTime Time,
    long ProjectTypeId
) : IRequest<WorkTimeTrackingDto>;

public sealed class CreateWorkTimeTrackingCommandValidator : AbstractValidator<CreateWorkTimeTrackingCommand>
{
    public CreateWorkTimeTrackingCommandValidator()
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

internal sealed class CreateWorkTimeTrackingCommandHandler : IRequestHandler<CreateWorkTimeTrackingCommand, WorkTimeTrackingDto>
{
    private readonly IWorkTimeTrackingRepository _workTimeTrackingRepository;
    private readonly IMapper _mapper;
    private readonly TimeProvider _timeProvider;

    public CreateWorkTimeTrackingCommandHandler(
        IWorkTimeTrackingRepository workTimeTrackingRepository,
        IMapper mapper,
        TimeProvider timeProvider)
    {
        _workTimeTrackingRepository = workTimeTrackingRepository;
        _mapper = mapper;
        _timeProvider = timeProvider;
    }

    public async Task<WorkTimeTrackingDto> Handle(CreateWorkTimeTrackingCommand request, CancellationToken cancellationToken)
    {
        // TODO
        var workTimeTracking = new WorkTimeTracking(request.Name, request.ShortDescription, request.ProjectTypeId)
        {
            CreatedDate = _timeProvider.GetLocalNow().DateTime,
            CreatedBy = 1
        };

        if (!string.IsNullOrEmpty(request.Description))
            workTimeTracking.SetDescription(request.Description);

        workTimeTracking.SetDateMin(request.DateMin);
        workTimeTracking.SetDateMax(request.DateMax);
        workTimeTracking.SetTime(request.Time);

        await _workTimeTrackingRepository.AddAsync(workTimeTracking, cancellationToken);
        await _workTimeTrackingRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<WorkTimeTrackingDto>(workTimeTracking);
    }
}

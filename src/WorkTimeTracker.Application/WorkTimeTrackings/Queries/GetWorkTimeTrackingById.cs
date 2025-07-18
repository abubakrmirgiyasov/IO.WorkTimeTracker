using AutoMapper;
using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.WorkTimeTrackings.Models;
using WorkTimeTracker.Application.WorkTimeTrackings.Repositories;
using WorkTimeTracker.Application.WorkTimeTrackings.Specifications;
using WorkTimeTracker.Shared.Exceptions;

namespace WorkTimeTracker.Application.WorkTimeTrackings.Queries;

public sealed record GetWorkTimeTrackingById(long Id) : IRequest<WorkTimeTrackingDto>;

public sealed class GetWorkTimeTrackingByIdValidator : AbstractValidator<GetWorkTimeTrackingById>
{
    public GetWorkTimeTrackingByIdValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}

internal sealed class GetWorkTimeTrackingByIdHandler : IRequestHandler<GetWorkTimeTrackingById, WorkTimeTrackingDto>
{
    private readonly IWorkTimeTrackingRepository _workTimeTrackingRepository;
    private readonly IMapper _mapper;

    public GetWorkTimeTrackingByIdHandler(IWorkTimeTrackingRepository workTimeTrackingRepository, IMapper mapper)
    {
        _workTimeTrackingRepository = workTimeTrackingRepository;
        _mapper = mapper;
    }

    public async Task<WorkTimeTrackingDto> Handle(GetWorkTimeTrackingById request, CancellationToken cancellationToken = default)
    {
        var spec = new WorkTimeTrackingByIdSpec(request.Id, asNoTracking: true);
        var workTimeTracking = await _workTimeTrackingRepository.FirstOrDefaultAsync(spec, cancellationToken);

        if (workTimeTracking is null)
            throw new ResourceNotFoundException(WorkTimeTrackingErrors.NotFound);

        return _mapper.Map<WorkTimeTrackingDto>(workTimeTracking);
    }
}

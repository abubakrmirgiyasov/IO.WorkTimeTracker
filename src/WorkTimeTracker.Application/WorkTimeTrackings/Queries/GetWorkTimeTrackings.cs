using Ardalis.Specification;
using AutoMapper;
using MediatR;
using WorkTimeTracker.Application.Common.Specifications;
using WorkTimeTracker.Application.WorkTimeTrackings.Models;
using WorkTimeTracker.Application.WorkTimeTrackings.Repositories;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.WorkTimeTrackings.Queries;

public sealed record GetWorkTimeTrackings : IRequest<List<WorkTimeTrackingDto>>;

internal sealed class GetWorkTimeTrackingsHandler : IRequestHandler<GetWorkTimeTrackings, List<WorkTimeTrackingDto>>
{
    private readonly IWorkTimeTrackingRepository _workTimeTrackingRepository;
    private readonly IMapper _mapper;

    public GetWorkTimeTrackingsHandler(IWorkTimeTrackingRepository workTimeTrackingRepository, IMapper mapper)
    {
        _workTimeTrackingRepository = workTimeTrackingRepository;
        _mapper = mapper;
    }

    public async Task<List<WorkTimeTrackingDto>> Handle(GetWorkTimeTrackings request, CancellationToken cancellationToken)
    {
        var spec = new DbSpecifications<WorkTimeTracking>();
        spec
            .Query
            .AsNoTracking()
            .Include(x => x.ProjectType);

        var workTimeTrackings = await _workTimeTrackingRepository.ListAsync(spec, cancellationToken);

        return _mapper.Map<List<WorkTimeTrackingDto>>(workTimeTrackings);
    }
}

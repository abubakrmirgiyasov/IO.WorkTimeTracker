using Ardalis.Specification;
using AutoMapper;
using MediatR;
using WorkTimeTracker.Application.Common.Specifications;
using WorkTimeTracker.Application.ProjectTypes.Models;
using WorkTimeTracker.Application.ProjectTypes.Repositories;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.ProjectTypes.Queries;

public sealed record GetProjectTypes : IRequest<List<ProjectTypeDto>>;

internal sealed class GetProjectTypesHandler : IRequestHandler<GetProjectTypes, List<ProjectTypeDto>>
{
    private readonly IProjectTypeRepository _projectTypeRepository;
    private readonly IMapper _mapper;

    public GetProjectTypesHandler(
        IProjectTypeRepository projectTypeRepository,
        IMapper mapper)
    {
        _projectTypeRepository = projectTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<ProjectTypeDto>> Handle(GetProjectTypes request, CancellationToken cancellationToken)
    {
        var spec = new DbSpecifications<ProjectType>();
        spec.Query.AsNoTracking();

        var types = await _projectTypeRepository.ListAsync(spec, cancellationToken);

        return _mapper.Map<List<ProjectTypeDto>>(types);
    }
}

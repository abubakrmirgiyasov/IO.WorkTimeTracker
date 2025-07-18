using AutoMapper;
using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.ProjectTypes.Models;
using WorkTimeTracker.Application.ProjectTypes.Repositories;
using WorkTimeTracker.Application.ProjectTypes.Specifications;
using WorkTimeTracker.Shared.Exceptions;

namespace WorkTimeTracker.Application.ProjectTypes.Queries;

public sealed record GetProjectTypeById(long ProjectTypeId) : IRequest<ProjectTypeDto>;

public sealed class GetProjectTypeByIdValidator : AbstractValidator<GetProjectTypeById>
{
    public GetProjectTypeByIdValidator()
    {
        RuleFor(x => x.ProjectTypeId).GreaterThan(0);
    }
}

internal sealed class GetProjectTypeByIdHandler : IRequestHandler<GetProjectTypeById, ProjectTypeDto>
{
    private readonly IProjectTypeRepository _projectTypeRepository;
    private readonly IMapper _mapper;

    public GetProjectTypeByIdHandler(
          IProjectTypeRepository projectTypeRepository,
          IMapper mapper)
    {
        _projectTypeRepository = projectTypeRepository;
        _mapper = mapper;
    }

    public async Task<ProjectTypeDto> Handle(GetProjectTypeById request, CancellationToken cancellationToken)
    {
        var spec = new ProjectTypeByIdSpec(request.ProjectTypeId, asNoTracking: true);
        var projectType = await _projectTypeRepository.FirstOrDefaultAsync(spec, cancellationToken);

        if (spec is null)
            throw new ResourceNotFoundException(ProjectTypeErrors.NotFound);

        return _mapper.Map<ProjectTypeDto>(projectType);
    }
}

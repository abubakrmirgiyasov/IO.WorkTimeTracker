using AutoMapper;
using FluentValidation;
using MediatR;
using WorkTimeTracker.Application.ProjectTypes.Models;
using WorkTimeTracker.Application.ProjectTypes.Repositories;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Application.ProjectTypes.Commands;

public sealed record CreateProjectTypeCommand(
    string Name,
    string? Description
) : IRequest<ProjectTypeDto>;

public sealed class CreateProjectTypeCommandValidator : AbstractValidator<CreateProjectTypeCommand>
{
    public CreateProjectTypeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty()
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}

internal sealed class CreateProjectTypeCommandHandler : IRequestHandler<CreateProjectTypeCommand, ProjectTypeDto>
{
    private readonly IProjectTypeRepository _projectTypeRepository;
    private readonly IMapper _mapper;
    private readonly TimeProvider _timeProvider;

    public CreateProjectTypeCommandHandler(
        IProjectTypeRepository projectTypeRepository,
        IMapper mapper,
        TimeProvider timeProvider)
    {
        _projectTypeRepository = projectTypeRepository;
        _mapper = mapper;
        _timeProvider = timeProvider;
    }

    public async Task<ProjectTypeDto> Handle(CreateProjectTypeCommand request, CancellationToken cancellationToken)
    {
        // TODO
        var projectType = new ProjectType(request.Name)
        {
            CreatedDate = _timeProvider.GetLocalNow().DateTime,
            CreatedBy = 1
        };

        if (!string.IsNullOrEmpty(request.Description))
            projectType.SetDescription(request.Description);

        await _projectTypeRepository.AddAsync(projectType, cancellationToken);
        await _projectTypeRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProjectTypeDto>(projectType);
    }
}

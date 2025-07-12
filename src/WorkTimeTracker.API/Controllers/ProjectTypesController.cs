using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkTimeTracker.API.Models.Requests;
using WorkTimeTracker.Application.ProjectTypes.Commands;
using WorkTimeTracker.Application.ProjectTypes.Models;
using WorkTimeTracker.Application.ProjectTypes.Queries;

namespace WorkTimeTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<ProjectTypeDto>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetProjectTypes(), cancellationToken);
    }

    [HttpGet("{id:long}")]
    public async Task<ProjectTypeDto> GetById(long id, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetProjectTypeById(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ProjectTypeDto> Create(
        [FromBody] CreateProjectTypeCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id:long}")]
    public async Task<NoContentResult> Update(
        long id,
        [FromBody] UpdateProjectTypeRequest request,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new UpdateProjectTypeCommand(
                id,
                Name: request.Name,
                Description: request.Description
            ),
            cancellationToken
        );

        return new NoContentResult();
    }

    [HttpDelete("{id:long}")]
    public async Task<NoContentResult> Delete(long id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new DeleteProjectTypeCommand(id), cancellationToken);
        return new NoContentResult();
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkTimeTracker.API.Models.Requests;
using WorkTimeTracker.Application.Projects.Commands;
using WorkTimeTracker.Application.Projects.Models;
using WorkTimeTracker.Application.Projects.Queries;

namespace WorkTimeTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<ProjectDto>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetProjects(), cancellationToken);
    }

    [HttpGet("{id:long}")]
    public async Task<ProjectDto> GetById(long id, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetProjectById(id), cancellationToken);
    }

    [HttpPost]
    public async Task<ProjectDto> Create(
        [FromBody] CreateProjectCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id:long}")]
    public async Task<NoContentResult> Update(
        long id,
        [FromBody] UpdateProjectRequest request,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new UpdateProjectCommand(
                id,
                Link: request.Link,
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
        await _mediator.Send(new DeleteProjectCommand(id), cancellationToken);
        return new NoContentResult();
    }
}

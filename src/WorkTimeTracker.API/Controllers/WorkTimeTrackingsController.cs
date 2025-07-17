using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkTimeTracker.API.Models.Requests;
using WorkTimeTracker.Application.WorkTimeTrackings.Commands;
using WorkTimeTracker.Application.WorkTimeTrackings.Models;
using WorkTimeTracker.Application.WorkTimeTrackings.Queries;

namespace WorkTimeTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkTimeTrackingsController : ControllerBase
{
    private readonly IMediator _mediator;
    public WorkTimeTrackingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<WorkTimeTrackingDto>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetWorkTimeTrackings(), cancellationToken);
    }

    [HttpGet("{id:long}")]
    public async Task<WorkTimeTrackingDto> GetById(long id, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetWorkTimeTrackingById(id), cancellationToken);
    }

    [HttpPost]
    public async Task<WorkTimeTrackingDto> Create(
        [FromBody] CreateWorkTimeTrackingCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id:long}")]
    public async Task<NoContentResult> Update(
        long id,
        [FromBody] UpdateWorkTimeTrackingRequest request,
        CancellationToken cancellationToken = default)
    {
        await _mediator.Send(
            new UpdateWorkTimeTrackingCommand(
                id,
                Name: request.Name,
                Description: request.Description,
                ShortDescription: request.ShortDescription,
                DateMin: request.DateMin,
                DateMax: request.DateMax,
                Time: request.Time,
                ProjectTypeId: request.ProjectTypeId
            ),
            cancellationToken
        );

        return new NoContentResult();
    }

    [HttpDelete("{id:long}")]
    public async Task<NoContentResult> Delete(long id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new DeleteWorkTimeTrackingCommand(id), cancellationToken);
        return new NoContentResult();
    }
}

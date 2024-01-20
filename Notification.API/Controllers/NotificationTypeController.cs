using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Aplication.Commands.CreateNotificationTypes;
using Notification.Aplication.Commands.UpdateNotificationType;

namespace Notification.API.Controllers; 
public class NotificationTypeController: NotificationController 
{
    [HttpPost]
    public async Task<IActionResult> CreateNotificationType([FromServices] IMediator _mediator, [FromBody] CreateNotificationsTypesCommand request) 
    {
        var Id = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetById), new { Id }, request);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById([FromServices] IMediator _mediator, [FromQuery] Guid Id) 
    {
        var result = await _mediator.Send(Id);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromServices] IMediator _mediator, string query) 
    {
        
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateNotificationType([FromServices] IMediator _mediator, [FromBody] UpdateNotificationTypesCommand request, [FromQuery] Guid Id) 
    {
        request.Id = Id;

        await _mediator.Send(request);

        return NoContent();
    }
}

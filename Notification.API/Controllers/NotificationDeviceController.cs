using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Aplication.Commands.NotificationDevice.CreateNotificationDevice;
using Notification.Aplication.Commands.NotificationDevice.UpdateNotificationDevice;
using Notification.Aplication.DTO.Response;
using Notification.Aplication.Queries.NotificationDevice.GetAllNotificationDevice;
using Notification.Aplication.Queries.NotificationDevice.GetByIdNotificationDevice;
using Notification.Aplication.Commands.NotificationDevice.DeleteNotificationDevice;

namespace Notification.API.Controllers; 
public class NotificationDeviceController : NotificationController 
{
    [HttpPost]
    public async Task<IActionResult> CreateNotificationType([FromServices] IMediator _mediator, [FromBody] CreateNotificationDeviceCommand request) 
    {
        var Id = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetById), new { Id }, request);
    }

    [HttpGet]
    [Route("GetById")]
    [ProducesResponseType(typeof(ResponseNotificationDevice), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromServices] IMediator _mediator, [FromQuery] Guid Id) 
    {
        var request = new GetByIdNotificationDeviceQuery(Id);

        var result = await _mediator.Send(request);

        return Ok(result);
    }


    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(typeof(ResponseNotificationDevice), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] IMediator _mediator, [FromQuery] string query) 
    {
        
        var request = new GetAllNotificationDeviceQuery(query);

        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateNotificationDevice([FromServices] IMediator _mediator, [FromBody] UpdateNotificationDeviceCommand request, [FromQuery] Guid Id) {
       
        request.Id = Id;

        await _mediator.Send(request);

        return NoContent();
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromServices] IMediator _mediator, [FromQuery] Guid Id) {
       
        var request = new DeleteNotificationDeviceCommand(Id);

        await _mediator.Send(request);

        return NoContent();
    }
}

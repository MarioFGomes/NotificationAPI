using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Aplication.Commands.NotificationTypes.CreateNotificationTypes;
using Notification.Aplication.Commands.NotificationTypes.DeleteNotificationTypes;
using Notification.Aplication.Commands.NotificationTypes.UpdateNotificationTypes;
using Notification.Aplication.DTO.Response;
using Notification.Aplication.Queries.NotificationTypes.GetAllNotificationTypes;
using Notification.Aplication.Queries.NotificationTypes.GetByIdNotificatioTypes;

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
    [Route("GetById/{Id:Guid}")]
    [ProducesResponseType(typeof(ResponseNotificationTypes), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromServices] IMediator _mediator,Guid Id) 
    {
     var request = new GetByIdNotificationTypesQuery(Id);

     var result = await _mediator.Send(request);

      return Ok(result);  
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(typeof(ResponseNotificationTypes), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] IMediator _mediator, string? query) 
    {
        var request = new GetAllNotificationTypesQuery(query);
        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpPut]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> UpdateNotificationType([FromServices] IMediator _mediator, [FromBody] UpdateNotificationTypesCommand request, Guid Id) 
    {
        request.Id = Id;

        await _mediator.Send(request);

        return NoContent();
    }
    [HttpDelete]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> Delete([FromServices] IMediator _mediator, Guid Id) 
    {
        var request = new DeleteNotificationTypeCommand(Id);

        await _mediator.Send(request);

        return NoContent() ;
    }
}

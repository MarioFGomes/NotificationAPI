using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Aplication.Commands.NotificationSend.CreateNotificationSend;
using Notification.Aplication.Commands.NotificationTemplate.CreateNotificationTemplate;
using Notification.Aplication.DTO.Response;
using Notification.Aplication.Queries.NotificationSend.GetByIdNotificationSend;
using Notification.Aplication.Queries.NotificationTemplate.GetAllNotificationTemplate;
using Notification.Aplication.Queries.NotificationTemplate.GetByIdNotificationTemplate;

namespace Notification.API.Controllers; 
public class NotificationSendController : NotificationController 
{

    [HttpPost]
    public async Task<IActionResult> CreateNotificationTemplate([FromServices] IMediator _mediator, [FromBody] CreateNotificationSendCommand request) 
    {

        var Id = await _mediator.Send(request);

        return NoContent();
    }


    [HttpGet]
    [Route("GetById/{Id:Guid}")]
    [ProducesResponseType(typeof(ResponseNotificationSend), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromServices] IMediator _mediator, Guid Id) {
        var request = new GetByIdNotificationSendQuery(Id);

        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(typeof(ResponseNotificationSend), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] IMediator _mediator, string? query) {

        var request = new GetAllNotificationTemplateCommand(query);
        var result = await _mediator.Send(request);

        return Ok(result);
    }
}

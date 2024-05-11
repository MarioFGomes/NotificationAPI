using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Aplication.Commands.NotificationSend.CreateNotificationSend;
using Notification.Aplication.Commands.NotificationSend.SendSMSNotification;
using Notification.Aplication.Commands.NotificationSend.SendWebEmailNotification;
using Notification.Aplication.DTO.Response;
using Notification.Aplication.Queries.NotificationSend.GetAllNotificationSend;
using Notification.Aplication.Queries.NotificationSend.GetByIdNotificationSend;


namespace Notification.API.Controllers; 
public class NotificationSendController : NotificationController 
{

    [HttpPost]
    [Route("device")]
    public async Task<IActionResult> SendNotificationOnDevice([FromServices] IMediator _mediator, [FromBody] CreateNotificationSendCommand request) 
    {

        var Id = await _mediator.Send(request);

        return NoContent();
    }

    [HttpPost]
    [Route("email/send")]
    public async Task<IActionResult> SendWebEmailNotification([FromServices] IMediator _mediator, [FromBody] SendWebEmailNotificationCommand request) {

        await _mediator.Send(request);

        return NoContent();
    }

    [HttpPost]
    [Route("sms/send")]
    public async Task<IActionResult> SendSMSNotification([FromServices] IMediator _mediator, [FromBody] SendSMSNotificationCommand request) {
        await _mediator.Send(request);

        return NoContent();
    }


    [HttpGet]
    [Route("GetById/{Id:Guid}")]
    [ProducesResponseType(typeof(ResponseNotificationSend), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromServices] IMediator _mediator, Guid Id) 
    {

        var request = new GetByIdNotificationSendQuery(Id);

        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(typeof(ResponseNotificationSend), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] IMediator _mediator, string? query) 
    {

        var request = new GetAllNotificationSendQuery(query);
        var result = await _mediator.Send(request);

        return Ok(result);
    }
}

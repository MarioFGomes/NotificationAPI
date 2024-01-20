using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Aplication.Commands.CreateNotificationTypes;

namespace Notification.API.Controllers; 
public class NotificationTypeController: NotificationController 
{
    [HttpPost]
    public async Task<IActionResult> CreateNotificationType([FromServices] IMediator _mediator, [FromBody] CreateNotificationsTypesCommand request) 
    {
        var resultado = await _mediator.Send(request);

        return Created(string.Empty, resultado);
    }
}

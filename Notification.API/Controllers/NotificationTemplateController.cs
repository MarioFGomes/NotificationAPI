using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Aplication.Commands.NotificationTemplate.CreateNotificationTemplate;
using Notification.Aplication.Commands.NotificationTemplate.DeleteNotificationTemplate;
using Notification.Aplication.Commands.NotificationTemplate.UpdateNotificationTemplate;
using Notification.Aplication.DTO.Response;
using Notification.Aplication.Queries.NotificationTemplate.GetAllNotificationTemplate;
using Notification.Aplication.Queries.NotificationTemplate.GetByIdNotificationTemplate;


namespace Notification.API.Controllers; 
public class NotificationTemplateController : NotificationController 
{
    [HttpPost]
    public async Task<IActionResult> CreateNotificationTemplate([FromServices] IMediator _mediator, [FromBody] CreateNotificationTemplateCommand request) 
    {
        
        var Id = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetById), new { Id }, request);
    }

    [HttpGet]
    [Route("GetById/{Id:Guid}")]
    [ProducesResponseType(typeof(ResponseNotificationTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromServices] IMediator _mediator, Guid Id) 
    {
        var request = new GetByIdNotificationTemplateCommand(Id);

        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(typeof(ResponseNotificationTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] IMediator _mediator, string? query) 
    {

        var request = new GetAllNotificationTemplateCommand(query);
        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpPut]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> UpdateNotificationTemplate([FromServices] IMediator _mediator, [FromBody] UpdateNotificationTemplateCommand request, Guid Id) 
    {
        
        request.Id = Id;

        await _mediator.Send(request);

        return NoContent();
    }


    [HttpDelete]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> Delete([FromServices] IMediator _mediator, Guid Id) 
    {
        var request = new DeleteNotificationTemplateCommand(Id);

        await _mediator.Send(request);

        return NoContent();
    }
}

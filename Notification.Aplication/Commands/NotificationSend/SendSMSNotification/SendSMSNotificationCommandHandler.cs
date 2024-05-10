using AutoMapper;
using MediatR;
using Notification.Aplication.Commands.NotificationSend.CreateNotificationSend;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationSend.SendSMSNotification;
public class SendSMSNotificationCommandHandler : IRequestHandler<SendSMSNotificationCommand, Unit> 
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;
    private readonly ISendSmsService _sendSmsService;
    private readonly INotificationSendRepository _notificationSendRepository;
    private readonly INotificationTemplateRepository _notificationTemplateRepository;
    public SendSMSNotificationCommandHandler(INotificationTemplateRepository notificationTemplate, IUnitofWork unitofWork, IMapper mapper, ISendSmsService sendSmsService, INotificationSendRepository notificationSendRepository)
    {
        _notificationTemplateRepository = notificationTemplate;
        _mapper = mapper;
        _notificationSendRepository = notificationSendRepository;
        _unitofWork = unitofWork;
        _sendSmsService= sendSmsService;
    }
    public async Task<Unit> Handle(SendSMSNotificationCommand request, CancellationToken cancellationToken) 
    {
        if(request.notificationTemplateId is not null) 
        {
            var notificationTemplate = await _notificationTemplateRepository.GetbyIdAsync(request.notificationTemplateId.Value) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

            await _sendSmsService.SendAsync(notificationTemplate.description, request.toPhoneNumber);
        } 
        else 
        {
            await _sendSmsService.SendAsync(request.Content, request.toPhoneNumber);
        }

        var result = _mapper.Map<Notification.Domain.Entities.NotificationSend>(request);

        await _notificationSendRepository.CreateAsync(result);

        await _unitofWork.Commit();

        return Unit.Value;
    }
}

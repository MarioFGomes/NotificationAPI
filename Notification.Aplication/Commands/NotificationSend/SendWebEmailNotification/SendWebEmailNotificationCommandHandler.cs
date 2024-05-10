using AutoMapper;
using MediatR;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Repositories;


namespace Notification.Aplication.Commands.NotificationSend.SendWebEmailNotification;
public class SendWebEmailNotificationCommandHandler : IRequestHandler<SendWebEmailNotificationCommand, Unit> 
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;
    private readonly ISendEmailService _SendEmailService;
    private readonly INotificationSendRepository _notificationSendRepository;
    private readonly INotificationTemplateRepository _notificationTemplateRepository;
    public SendWebEmailNotificationCommandHandler(INotificationTemplateRepository notificationTemplate, IUnitofWork unitofWork, IMapper mapper, ISendEmailService SendEmailService, INotificationSendRepository notificationSendRepository)
    {
        _notificationTemplateRepository = notificationTemplate;
        _mapper = mapper;
        _notificationSendRepository = notificationSendRepository;
        _unitofWork = unitofWork;
        _SendEmailService = SendEmailService;
    }
    public async Task<Unit> Handle(SendWebEmailNotificationCommand request, CancellationToken cancellationToken) 
    {
        if (request.notificationTemplateId is not null) {

            var notificationTemplate = await _notificationTemplateRepository.GetbyIdAsync(request.notificationTemplateId.Value) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

            await _SendEmailService.SendAsync(notificationTemplate.title, notificationTemplate.body, request.Email, request.FromName);
        } 
        else 
        {
            await _SendEmailService.SendAsync(request.subject, request.body, request.Email, request.FromName);
        }

        var result = _mapper.Map<Notification.Domain.Entities.NotificationSend>(request);
        await _notificationSendRepository.CreateAsync(result);
        await _unitofWork.Commit();

        return Unit.Value;
    }
}

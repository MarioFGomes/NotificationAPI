using AutoMapper;
using MediatR;
using Notification.Aplication.Commands.NotificationDevice.CreateNotificationDevice;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Enum;
using Notification.Domain.Repositories;


namespace Notification.Aplication.Commands.NotificationSend.CreateNotificationSend;
public class CreateNotificationSendCommandHandler : IRequestHandler<CreateNotificationSendCommand, Unit> 
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;
    private readonly INotificationSendRepository _notificationSendRepository;
    private readonly INotificationTemplateRepository _notificationTemplateRepository;
    private readonly INotificationDeviceRepository _notificationDeviceRepository;
    private readonly ISendEmailService _SendEmailService;
    private readonly ISendSmsService _sendSmsService;
    public CreateNotificationSendCommandHandler(IUnitofWork unitofWork, IMapper mapper, INotificationSendRepository notificationSendRepository, ISendEmailService sendEmailService, ISendSmsService sendSmsService, INotificationDeviceRepository notificationDevice , INotificationTemplateRepository notificationTemplate  )
    {
        _mapper= mapper;
        _notificationSendRepository= notificationSendRepository;
        _notificationTemplateRepository = notificationTemplate;
        _notificationDeviceRepository= notificationDevice;  
        _unitofWork = unitofWork;
        _SendEmailService = sendEmailService;
        _sendSmsService= sendSmsService;
    }
    public async Task<Unit> Handle(CreateNotificationSendCommand request, CancellationToken cancellationToken) 
    {
        await Validator(request);

        var notificationDevice = await _notificationDeviceRepository.GetbyIdAsync(request.notificationDeviceId) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

        var notificationTemplate = await _notificationTemplateRepository.GetbyIdAsync(request.notificationTemplateId) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

        if (notificationDevice.device_type== DeviceType.WebEmail) 
        {
            await _SendEmailService.SendAsync(notificationTemplate.title, notificationTemplate.description, notificationDevice.device_token, notificationDevice.Owner);
        }

        if (notificationDevice.device_type== DeviceType.Phone) 
        {
            await _sendSmsService.SendAsync(notificationTemplate.description, notificationDevice.device_token);
        }

        var result=_mapper.Map<Notification.Domain.Entities.NotificationSend>(request);

        await _notificationSendRepository.CreateAsync(result);

       await  _unitofWork.Commit();

        return Unit.Value;
    }

    private Task Validator(CreateNotificationSendCommand request) 
    {
        var validator = new CreateNotificationSendValidator();
        var result = validator.Validate(request);

        if (!result.IsValid) {
            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ValidationErrorException(messageError);
        }

        return Task.CompletedTask;
    }
}

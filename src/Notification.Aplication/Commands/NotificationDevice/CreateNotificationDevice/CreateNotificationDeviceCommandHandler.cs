using AutoMapper;
using MediatR;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Repositories;


namespace Notification.Aplication.Commands.NotificationDevice.CreateNotificationDevice;
public class CreateNotificationDeviceCommandHandler : IRequestHandler<CreateNotificationDeviceCommand, Guid> 
{
    private readonly INotificationDeviceRepository _notificationDeviceRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;
    public CreateNotificationDeviceCommandHandler(INotificationDeviceRepository notificationDeviceRepository, IUnitofWork unitofWork, IMapper mapper)
    {
        _notificationDeviceRepository = notificationDeviceRepository;
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateNotificationDeviceCommand request, CancellationToken cancellationToken) 
    {
        await Validator(request);
        var notificationDevice = _mapper.Map<Notification.Domain.Entities.NotificationDevice>(request);
        await _notificationDeviceRepository.CreateAsync(notificationDevice);
        await _unitofWork.Commit();
        return notificationDevice.Id;
    }

    private Task Validator(CreateNotificationDeviceCommand request) {
        var validator = new CreateNotificationDeviceValidator();
        var result = validator.Validate(request);

        if (!result.IsValid) {
            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ValidationErrorException(messageError);
        }

        return Task.CompletedTask;
    }
}

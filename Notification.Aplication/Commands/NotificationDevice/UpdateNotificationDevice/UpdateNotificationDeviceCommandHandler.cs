using AutoMapper;
using MediatR;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Repositories;


namespace Notification.Aplication.Commands.NotificationDevice.UpdateNotificationDevice;
public class UpdateNotificationDeviceCommandHandler : IRequestHandler<UpdateNotificationDeviceCommand, Unit> 
{
    private readonly INotificationDeviceRepository _notificationDeviceRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public UpdateNotificationDeviceCommandHandler(INotificationDeviceRepository notificationDeviceRepository, IUnitofWork unitofWork, IMapper mapper)
    {
        _notificationDeviceRepository= notificationDeviceRepository;
        _unitofWork= unitofWork;
        _mapper= mapper;
    }
    public async Task<Unit> Handle(UpdateNotificationDeviceCommand request, CancellationToken cancellationToken) 
    {
        await Validator(request);
        var notificationDevice = await _notificationDeviceRepository.GetbyIdAsync(request.Id) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

        notificationDevice = _mapper.Map(request, notificationDevice);

        notificationDevice.LastUpdate = DateTime.UtcNow;

        await _notificationDeviceRepository.UpdateAsync(notificationDevice);

        await _unitofWork.Commit();

        return Unit.Value;
    }

    public Task Validator(UpdateNotificationDeviceCommand request) 
    {
        var validator = new UpdateNotificationDeviceValidator();
        var result = validator.Validate(request);

        if (!result.IsValid) {
            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ValidationErrorException(messageError);
        }
        return Task.CompletedTask;
    }
}

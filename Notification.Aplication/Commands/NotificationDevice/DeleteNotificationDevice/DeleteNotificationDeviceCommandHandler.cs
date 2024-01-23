using MediatR;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Enum;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationDevice.DeleteNotificationDevice;
public class DeleteNotificationDeviceCommandHandler : IRequestHandler<DeleteNotificationDeviceCommand, Unit> 
{
    private readonly INotificationDeviceRepository _notificationDeviceRepository;
    private readonly IUnitofWork _unitofWork;

    public DeleteNotificationDeviceCommandHandler(INotificationDeviceRepository notificationDeviceRepository, IUnitofWork unitofWork)
    {
        _notificationDeviceRepository = notificationDeviceRepository;
        _unitofWork = unitofWork;
    }
    public async Task<Unit> Handle(DeleteNotificationDeviceCommand request, CancellationToken cancellationToken) 
    {
        var notificationDevice = await _notificationDeviceRepository.GetbyIdAsync(request.Id) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

        notificationDevice.Status = (int)NotificationStatus.Deleted;

        notificationDevice.LastUpdate = DateTime.UtcNow;

        await _unitofWork.Commit();

        return Unit.Value;
    }
}

using AutoMapper;
using MediatR;
using Notification.Aplication.DTO.Response;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationDevice.GetByIdNotificationDevice; 
public class GetByIdNotificationDeviceQueryHandler : IRequestHandler<GetByIdNotificationDeviceQuery, ResponseNotificationDevice>
{
    private readonly INotificationDeviceRepository _notificationDeviceRepository;
    private readonly IMapper _mapper;
    public GetByIdNotificationDeviceQueryHandler(INotificationDeviceRepository notificationDeviceRepository, IMapper mapper)
    {
        _notificationDeviceRepository = notificationDeviceRepository;
        _mapper = mapper;
    }

    public async Task<ResponseNotificationDevice> Handle(GetByIdNotificationDeviceQuery request, CancellationToken cancellationToken) 
    {
        var result = await _notificationDeviceRepository.GetbyIdAsync(request.Id) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

        var notificationDevice = _mapper.Map<ResponseNotificationDevice>(result);

        return notificationDevice;
    }
}

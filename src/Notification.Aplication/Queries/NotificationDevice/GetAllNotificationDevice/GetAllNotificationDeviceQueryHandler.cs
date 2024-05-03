using AutoMapper;
using MediatR;
using Notification.Aplication.DTO.Response;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationDevice.GetAllNotificationDevice;
public class GetAllNotificationDeviceQueryHandler : IRequestHandler<GetAllNotificationDeviceQuery, List<ResponseNotificationDevice>> 
{
    private readonly INotificationDeviceRepository _notificationDeviceRepository;
    private readonly IMapper _mapper;
    
    public GetAllNotificationDeviceQueryHandler(INotificationDeviceRepository notificationDeviceRepository, IMapper mapper)
    {
        _notificationDeviceRepository = notificationDeviceRepository;
        _mapper = mapper;
    }
    public async Task<List<ResponseNotificationDevice>> Handle(GetAllNotificationDeviceQuery request, CancellationToken cancellationToken) 
    {
        var result  = await _notificationDeviceRepository.GetAllAsync(request.Query);

        var notificationDevices = _mapper.Map<List<ResponseNotificationDevice>>(result);

        return notificationDevices;

    }
}

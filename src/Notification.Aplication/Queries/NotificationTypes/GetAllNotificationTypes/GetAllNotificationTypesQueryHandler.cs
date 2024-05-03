using AutoMapper;
using MediatR;
using Notification.Aplication.DTO.Response;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationTypes.GetAllNotificationTypes;
public class GetAllNotificationTypesQueryHandler : IRequestHandler<GetAllNotificationTypesQuery, List<ResponseNotificationTypes>>
{
    private readonly INotificationTypeRepository _notificationTypeRepository;
    private readonly IMapper _mapper;
    public GetAllNotificationTypesQueryHandler(INotificationTypeRepository notificationTypeRepository, IMapper mapper)
    {
        _notificationTypeRepository = notificationTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<ResponseNotificationTypes>> Handle(GetAllNotificationTypesQuery request, CancellationToken cancellationToken)
    {
        var notificationTypes = await _notificationTypeRepository.GetbyAllAsync(request.Query);

        var result = _mapper.Map<List<ResponseNotificationTypes>>(notificationTypes);

        return result;
    }
}

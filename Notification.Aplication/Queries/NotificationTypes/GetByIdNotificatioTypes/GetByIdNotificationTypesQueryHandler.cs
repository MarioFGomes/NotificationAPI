using AutoMapper;
using MediatR;
using Notification.Aplication.DTO.Response;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationTypes.GetByIdNotificatioTypes;

public class GetByIdNotificationTypesQueryHandler : IRequestHandler<GetByIdNotificationTypesQuery, ResponseNotificationTypes> 
{
    private readonly INotificationTypeRepository _notificationTypeRepository;
    private readonly IMapper _mapper;
    public GetByIdNotificationTypesQueryHandler(INotificationTypeRepository notificationTypeRepository, IMapper mapper)
    {
        _notificationTypeRepository = notificationTypeRepository;
        _mapper = mapper;
    }
    public async Task<ResponseNotificationTypes> Handle(GetByIdNotificationTypesQuery request, CancellationToken cancellationToken) 
    {
        var notificationTypes = await _notificationTypeRepository.GetbyIdAsync(request.Id);
     
        var result= _mapper.Map<ResponseNotificationTypes>(notificationTypes);

        return result;
    }
}

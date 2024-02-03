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

namespace Notification.Aplication.Queries.NotificationSend.GetByIdNotificationSend;
public class GetByIdNotificationSendQueryHandler : IRequestHandler<GetByIdNotificationSendQuery, ResponseNotificationSend> 
{
    private readonly INotificationSendRepository _notificationSendRepository;
    private readonly IMapper _mapper;
    public GetByIdNotificationSendQueryHandler(INotificationSendRepository notificationSendRepository, IMapper mapper)
    {
        _notificationSendRepository = notificationSendRepository;
        _mapper = mapper;
    }
    public async Task<ResponseNotificationSend> Handle(GetByIdNotificationSendQuery request, CancellationToken cancellationToken) 
    {
        var notificationSent = await _notificationSendRepository.GetbyIdAsync(request.ID) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

        var result=_mapper.Map<ResponseNotificationSend>(notificationSent);

        return result;
    }
}

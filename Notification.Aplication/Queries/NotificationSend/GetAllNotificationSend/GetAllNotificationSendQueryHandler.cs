using AutoMapper;
using MediatR;
using Notification.Aplication.DTO.Response;
using Notification.Domain.Repositories;


namespace Notification.Aplication.Queries.NotificationSend.GetAllNotificationSend;
public class GetAllNotificationSendQueryHandler : IRequestHandler<GetAllNotificationSendQuery, List<ResponseNotificationSend>> 
{
    private readonly INotificationSendRepository _notificationSendRepository;
    private readonly IMapper _mapper;
    public GetAllNotificationSendQueryHandler(INotificationSendRepository notificationSendRepository, IMapper mapper)
    {
        _notificationSendRepository = notificationSendRepository;
        _mapper = mapper;
    }
    public async Task<List<ResponseNotificationSend>> Handle(GetAllNotificationSendQuery request, CancellationToken cancellationToken) 
    {
        var notificationsent = await _notificationSendRepository.GetAllAsync(request.Query);
        var notificationsentList=_mapper.Map<List<ResponseNotificationSend>>(notificationsent);
        return notificationsentList;
    }
}

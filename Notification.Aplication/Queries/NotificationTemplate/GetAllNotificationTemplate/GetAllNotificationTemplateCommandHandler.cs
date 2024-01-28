using AutoMapper;
using MediatR;
using Notification.Aplication.DTO.Response;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationTemplate.GetAllNotificationTemplate;
public class GetAllNotificationTemplateCommandHandler : IRequestHandler<GetAllNotificationTemplateCommand, List<ResponseNotificationTemplate>> 
{
    private readonly INotificationTemplateRepository _notificationTemplateRepository;
    private readonly IMapper _mapper;
    public GetAllNotificationTemplateCommandHandler(INotificationTemplateRepository notificationTemplateRepository, IMapper mapper)
    {
        _notificationTemplateRepository= notificationTemplateRepository;
        _mapper= mapper;
    }
    public async Task<List<ResponseNotificationTemplate>> Handle(GetAllNotificationTemplateCommand request, CancellationToken cancellationToken) 
    {
        var notificationTemplate=await _notificationTemplateRepository.GetAllAsync(request.Query);
        var response = _mapper.Map<List<ResponseNotificationTemplate>>(notificationTemplate);
        return response;
    }
}

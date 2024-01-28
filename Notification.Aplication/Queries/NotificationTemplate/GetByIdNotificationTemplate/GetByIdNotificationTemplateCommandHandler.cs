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

namespace Notification.Aplication.Queries.NotificationTemplate.GetByIdNotificationTemplate; 
public class GetByIdNotificationTemplateCommandHandler : IRequestHandler<GetByIdNotificationTemplateCommand, ResponseNotificationTemplate> 
{
    private readonly INotificationTemplateRepository _notificationTemplateRepository;
    private readonly IMapper _mapper;
    public GetByIdNotificationTemplateCommandHandler(INotificationTemplateRepository notificationTemplateRepository, IMapper mapper )
    {
        _notificationTemplateRepository= notificationTemplateRepository;
        _mapper= mapper;
    }

    public async Task<ResponseNotificationTemplate> Handle(GetByIdNotificationTemplateCommand request, CancellationToken cancellationToken) 
    {
       var notificationTemplate=await _notificationTemplateRepository.GetbyIdAsync(request.Id) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);
       
        var response=_mapper.Map<ResponseNotificationTemplate>(notificationTemplate);

        return response;
    }
}

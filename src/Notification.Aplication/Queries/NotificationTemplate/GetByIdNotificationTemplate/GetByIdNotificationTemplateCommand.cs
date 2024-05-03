using MediatR;
using Notification.Aplication.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationTemplate.GetByIdNotificationTemplate;
public class GetByIdNotificationTemplateCommand : IRequest<ResponseNotificationTemplate> {
    public Guid Id {get;set;}

    public GetByIdNotificationTemplateCommand(Guid id)
    {
        Id=id;
    }
}

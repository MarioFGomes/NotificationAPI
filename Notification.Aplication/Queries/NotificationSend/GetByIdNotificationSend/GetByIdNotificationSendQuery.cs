using MediatR;
using Notification.Aplication.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationSend.GetByIdNotificationSend; 
public class GetByIdNotificationSendQuery :IRequest<ResponseNotificationSend>
{
    public Guid ID { get; set; }

    public GetByIdNotificationSendQuery(Guid Id)
    {
        ID = Id;
    }
}

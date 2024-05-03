using MediatR;
using Notification.Aplication.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationDevice.GetByIdNotificationDevice; 
public class GetByIdNotificationDeviceQuery:IRequest<ResponseNotificationDevice> 
{
    public Guid Id { get; set; }

    public GetByIdNotificationDeviceQuery(Guid id)
    {
        Id=id;
    }
}

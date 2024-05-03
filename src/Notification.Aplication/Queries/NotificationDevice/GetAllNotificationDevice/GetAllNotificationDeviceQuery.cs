using MediatR;
using Notification.Aplication.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationDevice.GetAllNotificationDevice; 
public class GetAllNotificationDeviceQuery:IRequest<List<ResponseNotificationDevice>>
{
    public string Query { get; set; }

    public GetAllNotificationDeviceQuery(string query)
    {
        Query = query;
    }
}

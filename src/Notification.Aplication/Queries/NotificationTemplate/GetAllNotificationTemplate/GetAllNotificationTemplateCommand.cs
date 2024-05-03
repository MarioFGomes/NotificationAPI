using MediatR;
using Notification.Aplication.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationTemplate.GetAllNotificationTemplate; 
public class GetAllNotificationTemplateCommand:IRequest<List<ResponseNotificationTemplate>> 
{
    public string Query { get; set; }

    public GetAllNotificationTemplateCommand(string query)
    {
        Query= query;
    }
}

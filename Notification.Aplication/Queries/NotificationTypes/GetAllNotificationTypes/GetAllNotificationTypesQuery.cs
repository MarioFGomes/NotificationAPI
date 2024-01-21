using MediatR;
using Notification.Aplication.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationTypes.GetAllNotificationTypes;
public class GetAllNotificationTypesQuery : IRequest<List<ResponseNotificationTypes>>
{
    public string? Query { get; set; }

    public GetAllNotificationTypesQuery(string query)
    {
        Query=query;
    }
    
}

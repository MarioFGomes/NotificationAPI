using MediatR;
using Notification.Aplication.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationTypes.GetByIdNotificatioTypes;

public class GetByIdNotificationTypesQuery:IRequest<ResponseNotificationTypes>
{
    public Guid Id { get; set; }
    public GetByIdNotificationTypesQuery(Guid id)
    {
        Id=id;
    }
}

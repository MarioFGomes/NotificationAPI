using MediatR;
using Notification.Aplication.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Queries.NotificationSend.GetAllNotificationSend; 
public class GetAllNotificationSendQuery :IRequest<List<ResponseNotificationSend>>
{

}

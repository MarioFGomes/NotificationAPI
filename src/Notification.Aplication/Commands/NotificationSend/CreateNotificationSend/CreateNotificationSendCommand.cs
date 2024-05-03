using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationSend.CreateNotificationSend; 
public class CreateNotificationSendCommand:IRequest<Unit> 
{
    public Guid notificationDeviceId { get; set; }=Guid.Empty;
    public Guid notificationTemplateId { get; set; }= Guid.Empty;
}

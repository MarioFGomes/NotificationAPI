using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationSend.CreateNotificationSend; 
public class CreateNotificationSendCommand:IRequest<Unit> 
{
    public string to { get; set; }
    public string from { get; set; }
    public Guid notificationDeviceId { get; set; }
    public Guid notificationTemplateId { get; set; }
}

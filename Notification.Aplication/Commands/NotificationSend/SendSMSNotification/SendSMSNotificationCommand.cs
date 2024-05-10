using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationSend.SendSMSNotification; 
public class SendSMSNotificationCommand: IRequest<Unit> 
{
    public string toPhoneNumber { get; set; }
    public string? Content { get; set; }
    public Guid? notificationTemplateId { get; set; }= Guid.Empty;
}

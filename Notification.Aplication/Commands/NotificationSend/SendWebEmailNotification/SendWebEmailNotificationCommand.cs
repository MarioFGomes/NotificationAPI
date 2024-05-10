using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationSend.SendWebEmailNotification; 
public class SendWebEmailNotificationCommand: IRequest<Unit> 
{
    public string Email { get; set; }
    public string body { get; set; }
    public string subject { get; set; }
    public string FromName { get; set; }
    public Guid? notificationTemplateId { get; set; } = Guid.Empty;
}

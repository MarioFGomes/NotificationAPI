using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTemplate.UpdateNotificationTemplate; 
public class UpdateNotificationTemplateCommand :IRequest<Unit>
{
    public Guid Id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string body { get; set; }
    public Guid NotificationTypeId { get; set; }
}

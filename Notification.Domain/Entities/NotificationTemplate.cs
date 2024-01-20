using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities; 
public class NotificationTemplate: BaseEntity 
{
    public string title { get; set; }
    public string description { get; set; }
    public string body { get; set; }
    public Guid NotificationTypeId { get; set; }
    public virtual NotificationType notificationType { get; set; }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities; 
public class NotificationSend: BaseEntity 
{
    public string to { get; set; }
    public string from { get; set; }
    public Guid notificationDeviceId { get; set; }
    public Guid notificationTemplateId { get; set; }
    public virtual NotificationTemplate notificationTemplate { get; set; }
    public virtual NotificationDevice notificationDevice { get; set; }

}

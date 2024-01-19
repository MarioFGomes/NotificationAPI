using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities; 
public class NotificationSent: BaseEntity 
{
    public string to { get; set; }
    public string from { get; set; }
    public Guid notificationTemplateId { get; set; }
    public NotificationTemplate notificationTemplate { get; set; }
    public Guid notificationDeviceId { get; set; }
    public NotificationDevice notificationDevice { get; set; }

}

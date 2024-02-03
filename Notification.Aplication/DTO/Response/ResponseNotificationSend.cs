using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.DTO.Response; 
public class ResponseNotificationSend 
{
    public string to { get; set; }
    public string from { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string body { get; set; }
    public Guid notificationDeviceId { get; set; }
    public Guid notificationTemplateId { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.DTO.Response; 
public class ResponseNotificationDevice 
{
    public string Owner { get; set; }
    public string description { get; set; }
    public string device_type { get; set; }
    public string device_token { get; set; }
}

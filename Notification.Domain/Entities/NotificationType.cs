using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities; 
public class NotificationType: BaseEntity 
{
    public string name { get; set; }
    public string description { get; set; }


}

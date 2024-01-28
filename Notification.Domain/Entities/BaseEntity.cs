using Notification.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities; 
public class BaseEntity 
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Status { get; set; }
    public DateTime LastUpdate { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Status = (int)NotificationStatus.Active;
        LastUpdate = DateTime.UtcNow;
    }
}

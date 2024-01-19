using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Repositories; 
public interface INotificationDeviceRepository 
{
    Task CreateAsync(NotificationDevice request);
    Task UpdateAsync(NotificationDevice request);
    Task<NotificationDevice> GetbyIdAsync(Guid Id);
    Task<ICollection<NotificationDevice>> GetbyAllAsync(string query);

}

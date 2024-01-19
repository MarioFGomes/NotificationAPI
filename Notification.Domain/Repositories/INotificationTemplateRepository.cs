using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Repositories; 
public interface INotificationTemplateRepository 
{
    Task CreateAsync(NotificationTemplate request);
    Task UpdateAsync(NotificationTemplate request);
    Task<NotificationTemplate> GetbyIdAsync(Guid Id);
    Task<ICollection<NotificationTemplate>> GetbyAllAsync(string query);
}

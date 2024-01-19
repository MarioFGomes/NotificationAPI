using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Repositories; 
public interface INotificationSentRepository 
{
    Task CreateAsync(NotificationSent request);
    Task UpdateAsync(NotificationSent request);
    Task<NotificationSent> GetbyIdAsync(Guid Id);
    Task<ICollection<NotificationSent>> GetbyAllAsync(string query);
}

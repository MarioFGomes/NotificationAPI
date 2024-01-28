using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Repositories; 
public interface INotificationSendRepository 
{
    Task CreateAsync(NotificationSend request);
    Task<NotificationSend> GetbyIdAsync(Guid Id);
    Task<ICollection<NotificationSend>> GetbyAllAsync(string query);
}

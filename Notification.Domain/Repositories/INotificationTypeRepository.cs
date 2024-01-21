using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Repositories; 
public interface INotificationTypeRepository 
{
    Task CreateAsync(NotificationType request);
    Task UpdateAsync(NotificationType request);
    Task<NotificationType> GetbyIdAsync(Guid Id);
    Task<ICollection<NotificationType>> GetbyAllAsync(string? query);
}

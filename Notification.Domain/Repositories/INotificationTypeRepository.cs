using Notification.Domain.Entities;

namespace Notification.Domain.Repositories; 
public interface INotificationTypeRepository 
{
    Task CreateAsync(NotificationType request);
    Task UpdateAsync(NotificationType request);
    Task<NotificationType> GetbyIdAsync(Guid Id);
    Task<ICollection<NotificationType>> GetbyAllAsync(string? query);
}

using Azure.Core;
using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess.Repository;
public class NotificationTypeRepository : INotificationTypeRepository 
{
    private readonly NotificationContext _db;
    public NotificationTypeRepository(NotificationContext notificationContext)
    {
        _db = notificationContext;
    }
    public async Task CreateAsync(NotificationType request) {
      
        await _db.notificationTypes.AddAsync(request);
    }

    public async Task<ICollection<NotificationType>> GetbyAllAsync(string query) 
    {

        IQueryable<NotificationType> notificationType = _db.notificationTypes;

        if (!string.IsNullOrWhiteSpace(query)) {
            notificationType = notificationType.Where(u => u.Name.Contains(query) || u.Description.Contains(query));

        }
        return await notificationType.ToListAsync();
    }

    public async Task<NotificationType> GetbyIdAsync(Guid Id) 
    {
        return await _db.notificationTypes.SingleOrDefaultAsync(u => u.Id == Id); 
    }

    public Task UpdateAsync(NotificationType request) {
       _db.notificationTypes.Update(request);
        return Task.CompletedTask;
    }
}

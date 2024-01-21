using Azure.Core;
using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
      
        await _db.NotificationTypes.AddAsync(request);
    }

    public async Task<ICollection<NotificationType?>> GetbyAllAsync(string? query) 
    {

        IQueryable<NotificationType?> notificationType = _db.NotificationTypes;

        if (!string.IsNullOrWhiteSpace(query)) {
            
            notificationType = notificationType.Where(u => u.name.Contains(query) || u.description.Contains(query) && u.Status==1);

        }
        return await notificationType.ToListAsync();
    }

    public async Task<NotificationType?> GetbyIdAsync(Guid Id) 
    {
        return await _db.NotificationTypes.SingleOrDefaultAsync(u => u.Id.Equals(Id) && u.Status==1); 
    }

    public Task UpdateAsync(NotificationType request) {
       _db.NotificationTypes.Update(request);
        return Task.CompletedTask;
    }
}

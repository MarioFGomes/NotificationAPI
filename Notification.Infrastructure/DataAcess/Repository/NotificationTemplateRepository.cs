using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Domain.Enum;

namespace Notification.Infrastructure.DataAcess.Repository;
public class NotificationTemplateRepository : INotificationTemplateRepository 
{
    private readonly NotificationContext _db;
    public NotificationTemplateRepository(NotificationContext notificationContext)
    {
        _db = notificationContext;
    }
    public async Task CreateAsync(NotificationTemplate request) 
    {
        await _db.NotificationTemplate.AddAsync(request);
    }

    public async Task<ICollection<NotificationTemplate?>> GetbyAllAsync(string query) 
    {
        IQueryable<NotificationTemplate?> notificationTemplate = _db.NotificationTemplate.Where(u=>u.Status== (int)NotificationStatus.Active);

        if (!string.IsNullOrWhiteSpace(query)) {
            notificationTemplate = notificationTemplate.Where(u => u.title.Contains(query) || u.description.Contains(query));

        }
        return await notificationTemplate.ToListAsync();
    }

    public Task<NotificationTemplate?> GetbyIdAsync(Guid Id) 
    {
        return _db.NotificationTemplate.SingleOrDefaultAsync(t => t.Id == Id && t.Status== (int)NotificationStatus.Active);
    }

    public Task UpdateAsync(NotificationTemplate request) 
     {
        _db.NotificationTemplate.Update(request);

        return Task.CompletedTask;
    }
}

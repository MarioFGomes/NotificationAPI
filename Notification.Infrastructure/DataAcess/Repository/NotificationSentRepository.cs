using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess.Repository;
public class NotificationSentRepository : INotificationSentRepository 
{
    private readonly NotificationContext _db;

    public NotificationSentRepository(NotificationContext notificationContext)
    {
        _db = notificationContext;
    }
    public async Task CreateAsync(NotificationSent request) 
    {

        await _db.notificationSent.AddAsync(request);
    }

    public async Task<ICollection<NotificationSent>> GetbyAllAsync(string query) 
    {
        IQueryable<NotificationSent> notificationsents = _db.notificationSent;

        if (!string.IsNullOrWhiteSpace(query)) {
            notificationsents = notificationsents.Where(u => u.from.Contains(query) || u.to.Contains(query));

        }
        return await notificationsents.ToListAsync();
    }

    public async Task<NotificationSent> GetbyIdAsync(Guid Id) 
    {
        return await _db.notificationSent.SingleOrDefaultAsync(u => u.Id == Id);
    }

    public Task UpdateAsync(NotificationSent request) 
    {
        _db.notificationSent.Update(request);
        return Task.CompletedTask;
    }
}

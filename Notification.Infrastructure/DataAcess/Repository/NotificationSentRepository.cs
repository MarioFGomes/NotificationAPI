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
public class NotificationSentRepository : INotificationSentRepository 
{
    private readonly NotificationContext _db;

    public NotificationSentRepository(NotificationContext notificationContext)
    {
        _db = notificationContext;
    }
    public async Task CreateAsync(NotificationSent request) 
    {

        await _db.NotificationSent.AddAsync(request);
    }

    public async Task<ICollection<NotificationSent?>> GetbyAllAsync(string query) 
    {
        IQueryable<NotificationSent?> notificationsents = _db.NotificationSent.Where(s=>s.Status== (int)NotificationStatus.Active);

        if (!string.IsNullOrWhiteSpace(query)) {
            notificationsents = notificationsents.Where(u => u.from.Contains(query) || u.to.Contains(query));

        }
        return await notificationsents.ToListAsync();
    }

    public async Task<NotificationSent?> GetbyIdAsync(Guid Id) 
    {
        return await _db.NotificationSent.SingleOrDefaultAsync(u => u.Id == Id && u.Status== (int)NotificationStatus.Active);
    }

    public Task UpdateAsync(NotificationSent request) 
    {
      _db.NotificationSent.Update(request);

      return Task.CompletedTask;
    }
}

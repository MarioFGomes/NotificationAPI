using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Notification.Domain.Enum;

namespace Notification.Infrastructure.DataAcess.Repository;
public class NotificationSendRepository : INotificationSendRepository 
{
    private readonly NotificationContext _db;

    public NotificationSendRepository(NotificationContext notificationContext)
    {
        _db = notificationContext;
    }
    public async Task CreateAsync(NotificationSend request) 
    {

        await _db.NotificationSent.AddAsync(request);
    }

    public async Task<ICollection<NotificationSend?>> GetAllAsync(string query) 
    {
        IQueryable<NotificationSend?> notificationsents = _db.NotificationSent.Include(s=>s.notificationTemplate).Include(s=>s.notificationDevice).Where(s=>s.Status== (int)NotificationStatus.Active);

        if (!string.IsNullOrWhiteSpace(query)) {
            notificationsents = notificationsents.Where(u => u.from.Contains(query) || u.to.Contains(query));

        }
        return await notificationsents.ToListAsync();
    }

    public async Task<NotificationSend?> GetbyIdAsync(Guid Id) 
    {
        return await _db.NotificationSent.Include(u=>u.notificationTemplate).Include(u=>u.notificationDevice).SingleOrDefaultAsync(u => u.Id == Id && u.Status== (int)NotificationStatus.Active);
    }
}

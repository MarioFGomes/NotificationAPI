using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Domain.Enum;

namespace Notification.Infrastructure.DataAcess.Repository {
    public class NotificationDeviceRepository : INotificationDeviceRepository {
        private readonly NotificationContext _db;
        public NotificationDeviceRepository(NotificationContext notificationContext)
        {
            _db = notificationContext;
        }
        public async Task  CreateAsync(NotificationDevice request) {
            await _db.NotificationDevices.AddAsync(request);
        }

        public async Task<ICollection<NotificationDevice?>> GetAllAsync(string query) {
            IQueryable<NotificationDevice?> notificationDevices = _db.NotificationDevices.Where(d=>d.Status== (int)NotificationStatus.Active);

            if (!string.IsNullOrWhiteSpace(query)) {
                notificationDevices = notificationDevices.Where(u => u.description.Contains(query) || u.device_token.Contains(query));

            }
            return await notificationDevices.ToListAsync();
        }

        public async Task<NotificationDevice?> GetbyIdAsync(Guid Id) 
        { 
            return await _db.NotificationDevices.SingleOrDefaultAsync(e => e.Id == Id && e.Status== (int)NotificationStatus.Active);
        }

        public  Task UpdateAsync(NotificationDevice request) 
        {
            
            _db.NotificationDevices.Update(request);

            return Task.CompletedTask;
        }
    }
}

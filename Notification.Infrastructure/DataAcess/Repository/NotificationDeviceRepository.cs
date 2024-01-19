using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess.Repository {
    public class NotificationDeviceRepository : INotificationDeviceRepository {
        private readonly NotificationContext _db;
        public NotificationDeviceRepository(NotificationContext notificationContext)
        {
            _db = notificationContext;
        }
        public async Task  CreateAsync(NotificationDevice request) {
            await _db.notificationDevices.AddAsync(request);
        }

        public async Task<ICollection<NotificationDevice>> GetbyAllAsync(string query) {
            IQueryable<NotificationDevice> notificationDevices = _db.notificationDevices;

            if (!string.IsNullOrWhiteSpace(query)) {
                notificationDevices = notificationDevices.Where(u => u.description.Contains(query) || u.device_token.Contains(query));

            }
            return await notificationDevices.ToListAsync();
        }

        public async Task<NotificationDevice> GetbyIdAsync(Guid Id) 
        {
           
            return await _db.notificationDevices.SingleOrDefaultAsync(e => e.Id == Id);
        }

        public  Task UpdateAsync(NotificationDevice request) 
        {
            
            _db.notificationDevices.Update(request);

            return Task.CompletedTask;
        }
    }
}

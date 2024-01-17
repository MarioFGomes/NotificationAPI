using Microsoft.EntityFrameworkCore;
using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess
{
    public class NotificationContext : DbContext
    {

        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options) { }

        public DbSet<NotificationDevice> notificationDevices { get; set; }
        public DbSet<NotificationTemplate> notificationTemplates { get; set; }

        public DbSet<NotificationSent> notificationSentsSent { get; set; }

        public DbSet<NotificationType> notificationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationContext).Assembly);

        }

    }
}

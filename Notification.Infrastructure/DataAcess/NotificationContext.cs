using Microsoft.EntityFrameworkCore;
using Notification.Domain.Entities;
using Notification.Infrastructure.DataAcess.Migrations.Seeds;
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

        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options) {}

        public DbSet<NotificationDevice> NotificationDevices { get; set; }
        public DbSet<NotificationTemplate> NotificationTemplate { get; set; }

        public DbSet<NotificationSend> NotificationSent { get; set; }

        public DbSet<NotificationType> NotificationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationContext).Assembly);

            

        }

    }
}

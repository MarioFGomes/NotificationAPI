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

        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options) 
        {
           
        }

        public DbSet<NotificationDevice> NotificationDevices { get; set; }
        public DbSet<NotificationTemplate> NotificationTemplates { get; set; }

        public DbSet<NotificationSend> NotificationSents { get; set; }

        public DbSet<NotificationType> NotificationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationContext).Assembly);
          

        }

        public void _SetChangesValue() {

            var added = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added) {
                if (entity is BaseEntity) {
                    BaseEntity track = entity as BaseEntity;
                    track.CreatedAt = DateTime.UtcNow;
                    track.LastUpdate = DateTime.UtcNow;

                }
            }

            var modified = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in modified) {
                if (entity is BaseEntity) {
                    var track = entity as BaseEntity;
                    track.LastUpdate = DateTime.UtcNow;
                    track.CreatedAt=DateTime.Parse(track.CreatedAt.ToString()).ToUniversalTime();
                }
            }
        }

    }
}

using FluentMigrator;

namespace Notification.Infrastructure.DataAcess.Migrations.Seeds;

[Migration((long)VersionNumbers.SeedData, "Notification SeedData")]
public class SeedData : Migration {
 
    public override void Down() 
    {

        Delete.FromTable("NotificationTypes")
             .Row(new {
                 Id = Guid.NewGuid(),
                 CreatedAt = DateTime.UtcNow,
                 LastUpdate = DateTime.UtcNow,
                 Status = 1,
                 name = "Verification Code",
                 description = "Verification code for reset password"
             })
             .Row(new {
                 Id = Guid.NewGuid(),
                 CreatedAt = DateTime.UtcNow,
                 LastUpdate = DateTime.UtcNow,
                 Status = 1,
                 name = "User Created",
                 description = "When same user is created"
             });

    }

    public override void Up() 
    {

        Insert.IntoTable("NotificationTypes")
              .Row(new {
                   Id= Guid.NewGuid(),
                   CreatedAt=DateTime.UtcNow,
                   LastUpdate=DateTime.UtcNow,
                   Status=1,
                   name = "Verification Code", 
                   description = "Verification code for reset password" 
              })
              .Row(new {
                  Id = Guid.NewGuid(),
                  CreatedAt = DateTime.UtcNow,
                  LastUpdate = DateTime.UtcNow,
                  Status = 1,
                  name = "User Created",      
                  description = "When same user is created" 
              });     
    }
}

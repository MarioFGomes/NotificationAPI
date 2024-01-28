using FluentMigrator;

namespace Notification.Infrastructure.DataAcess.Migrations.Seeds;

[Migration((long)VersionNumbers.SeedData, "Notification SeedData")]
public class SeedData : Migration {
 
    public override void Down() 
    {

        Delete.FromTable("NotificationTypes")
          .Row(new { name = "Verification Code", description = "Verification code for reset password" })
          .Row(new { name = "User Created",      description = "When same user is created" });

    }

    public override void Up() 
    {

        Insert.IntoTable("NotificationTypes")
              .Row(new { name = "Verification Code", description = "Verification code for reset password" })
              .Row(new { name = "User Created",      description = "When same user is created" });     
    }
}

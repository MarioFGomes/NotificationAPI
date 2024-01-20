using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess.Migrations.Version;

[Migration((long)VersionNumbers.CreateNotificationTable, "Cria tabelas para notification")]
public class Version001 : Migration {
    public override void Down() {
        throw new NotImplementedException();
    }

    public override void Up() {

        var NotificationDevice = BaseVersion.InsarirColunasPadrao(Create.Table("NotificationDevices"));

        NotificationDevice
              .WithColumn("Owner").AsString(200).NotNullable()
              .WithColumn("description").AsString(150).NotNullable()
              .WithColumn("device_type").AsString(50).NotNullable()
              .WithColumn("device_token").AsString(200).NotNullable();


        var NotificationType = BaseVersion.InsarirColunasPadrao(Create.Table("NotificationTypes"));

        NotificationType
              .WithColumn("name").AsString(150).NotNullable()
              .WithColumn("description").AsString(200).NotNullable();


        var NotificationTemplate = BaseVersion.InsarirColunasPadrao(Create.Table("NotificationTemplate"));

        NotificationTemplate
              .WithColumn("title").AsString(100).NotNullable()
              .WithColumn("description").AsString(200).NotNullable()
              .WithColumn("body").AsString(2000).NotNullable()
              .WithColumn("NotificationTypeId").AsGuid().NotNullable();


        var NotificationSent = BaseVersion.InsarirColunasPadrao(Create.Table("NotificationSent"));

        NotificationSent
              .WithColumn("to").AsString(200).NotNullable()
              .WithColumn("from").AsString(200).NotNullable()
              .WithColumn("notificationTemplateId").AsGuid().NotNullable()
              .WithColumn("notificationDeviceId").AsGuid().NotNullable();
    }
}

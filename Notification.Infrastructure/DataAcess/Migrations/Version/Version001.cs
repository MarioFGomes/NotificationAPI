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
              .WithColumn("description").AsString(150).Nullable()
              .WithColumn("device_type").AsInt64().NotNullable()
              .WithColumn("device_token").AsString(200).NotNullable();


        var NotificationType = BaseVersion.InsarirColunasPadrao(Create.Table("NotificationTypes"));

        NotificationType
              .WithColumn("name").AsString(150).NotNullable()
              .WithColumn("description").AsString(200).NotNullable();


        var NotificationTemplate = BaseVersion.InsarirColunasPadrao(Create.Table("NotificationTemplates"));

        NotificationTemplate
              .WithColumn("title").AsString(100).NotNullable()
              .WithColumn("description").AsString(200).NotNullable()
              .WithColumn("body").AsString(2000).NotNullable()
              .WithColumn("NotificationTypeId").AsGuid().ForeignKey("NotificationTypes","Id").NotNullable();


        var NotificationSent = BaseVersion.InsarirColunasPadrao(Create.Table("NotificationSents"));

        NotificationSent
              .WithColumn("to").AsString(200).Nullable()
              .WithColumn("from").AsString(200).Nullable()
              .WithColumn("notificationTemplateId").AsGuid().ForeignKey("NotificationTemplates","Id").NotNullable()
              .WithColumn("notificationDeviceId").AsGuid().ForeignKey("NotificationDevices","Id").Nullable();
    }
}

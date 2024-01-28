using AutoMapper;
using Notification.Aplication.Commands.NotificationDevice.CreateNotificationDevice;
using Notification.Aplication.Commands.NotificationDevice.UpdateNotificationDevice;
using Notification.Aplication.Commands.NotificationTemplate.CreateNotificationTemplate;
using Notification.Aplication.Commands.NotificationTemplate.UpdateNotificationTemplate;
using Notification.Aplication.Commands.NotificationTypes.CreateNotificationTypes;
using Notification.Aplication.Commands.NotificationTypes.DeleteNotificationTypes;
using Notification.Aplication.Commands.NotificationTypes.UpdateNotificationTypes;
using Notification.Aplication.DTO.Response;
using Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Service.Automapper;
public class AutoMapperConfiguration: Profile 
{
    public AutoMapperConfiguration()
    {
        CreateMap<CreateNotificationsTypesCommand, NotificationType>();
        CreateMap<UpdateNotificationTypesCommand, NotificationType>();
        CreateMap<DeleteNotificationTypeCommand, NotificationType>();
        CreateMap<NotificationType, ResponseNotificationTypes>();
        CreateMap<CreateNotificationDeviceCommand,NotificationDevice>();
        CreateMap<NotificationDevice, ResponseNotificationDevice>();
        CreateMap<UpdateNotificationDeviceCommand, NotificationDevice>();
        CreateMap<CreateNotificationTemplateCommand, NotificationTemplate>();
        CreateMap<NotificationTemplate, ResponseNotificationTemplate>();
        CreateMap<UpdateNotificationTemplateCommand, NotificationTemplate>();
    }
}

using AutoMapper;
using Notification.Aplication.Commands.CreateNotificationTypes;
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
    }
}

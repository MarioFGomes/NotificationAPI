using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTypes.CreateNotificationTypes;
public class CreateNotificationsTypesCommand : IRequest<Guid>
{
    public string name { get; set; }
    public string description { get; set; }
}

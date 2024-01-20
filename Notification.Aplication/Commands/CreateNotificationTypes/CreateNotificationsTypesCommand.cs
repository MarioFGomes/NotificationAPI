using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.CreateNotificationTypes; 
public class CreateNotificationsTypesCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}

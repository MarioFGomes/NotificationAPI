using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationDevice.DeleteNotificationDevice; 
public class DeleteNotificationDeviceCommand:IRequest<Unit> 
{
    public Guid Id { get; set; }

    public DeleteNotificationDeviceCommand(Guid id)
    {
        Id=id;
    }
}

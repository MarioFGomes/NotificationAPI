using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTypes.DeleteNotificationTypes; 
public class DeleteNotificationTypeCommand:IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteNotificationTypeCommand(Guid id)
    {
        Id= id;
    }
}

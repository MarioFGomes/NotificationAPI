using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTemplate.DeleteNotificationTemplate; 
public class DeleteNotificationTemplateCommand:IRequest<Unit> 
{
    public Guid Id { get; set; }

    public DeleteNotificationTemplateCommand(Guid id)
    {
        Id = id;
    }
}

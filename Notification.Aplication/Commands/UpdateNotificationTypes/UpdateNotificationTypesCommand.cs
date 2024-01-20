using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.UpdateNotificationType; 
public class UpdateNotificationTypesCommand :IRequest<Unit>
{
    public Guid Id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}

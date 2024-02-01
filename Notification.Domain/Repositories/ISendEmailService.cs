using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Repositories; 
public interface ISendEmailService 
{
    Task SendAsync(string subject, string content, string toEmail, string toName);
    Task SendNativeAsync(string subject, string content, string toEmail, string toName);
}

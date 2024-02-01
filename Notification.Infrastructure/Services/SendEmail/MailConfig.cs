using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.Services.SendEmail; 
public class MailConfig 
{
    public string SendGridApiKey { get; set; }
    public string FromName { get; set; }
    public string FromEmail { get; set; }
}

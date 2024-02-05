using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.Services.SendSMS; 
public class SmsConfig 
{
    public string AccountSid { get; set; }
    public string AuthToken { get; set; }
    public string FromNumber { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.ExceptionBase;
[Serializable]
public class NotificationExceptions: SystemException 
{
    public NotificationExceptions(string messages):base(messages)
    {
        
    }

    protected NotificationExceptions(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

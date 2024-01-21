using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.ExceptionBase;
public class GenericErrorException : NotificationExceptions {
    public GenericErrorException(string messages) : base(messages) 
    {
    }

    protected GenericErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

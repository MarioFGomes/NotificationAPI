using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.ExceptionBase; 
public class ValidationErrorException: NotificationExceptions {
    public List<string> MessagesErros { get; set; }

    public ValidationErrorException(List<string> Erros) : base(string.Empty) {
        MessagesErros = Erros;
    }
    protected ValidationErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

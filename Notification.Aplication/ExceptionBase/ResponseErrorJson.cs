using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.ExceptionBase; 
public class ResponseErrorJson 
{
    public List<string> Mensagem { get; set; }
    public ResponseErrorJson(string messagem) {
        Mensagem = new List<string>
        {
            messagem
        };
    }

    public ResponseErrorJson(List<string> messagem) {
        Mensagem = messagem;
    }
}

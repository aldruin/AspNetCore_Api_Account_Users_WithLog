using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Domain.Notifications;
public class Notificacao
{
    public required string Acao { get; set; }
    public required string Mensagem { get; set; }
}

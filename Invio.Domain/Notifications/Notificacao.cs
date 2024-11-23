using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Domain.Notifications;
public class Notificacao
{
    public required string Key { get; set; }
    public required string Message { get; set; }
}

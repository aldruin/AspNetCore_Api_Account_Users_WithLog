using Invio.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Application.Interfaces;
public interface INotificationHandler
{
    List<Notificacao> ObterNotificacoes();
    bool TemNotificacao();
    bool AdicionarNotificacao(Notificacao notificacao);
    bool AdicionarNotificacao(string acao, string mensagem);
}

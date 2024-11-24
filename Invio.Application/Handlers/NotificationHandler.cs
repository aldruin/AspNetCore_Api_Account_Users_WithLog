using Invio.Application.Interfaces;
using Invio.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Application.Handlers;
public class NotificationHandler : INotificationHandler
{
    private readonly List<Notificacao> _notificacaoLista;

    public NotificationHandler(List<Notificacao> notificacaoLista)
    {
        _notificacaoLista = new List<Notificacao>();
    }

    public bool AdicionarNotificacao(Notificacao notificacao)
    {
        _notificacaoLista.Add(notificacao);
        return false;
    }

    public bool AdicionarNotificacao(string acao, string mensagem)
    {
        var notificacao = new Notificacao()
        {
            Acao = acao,
            Mensagem = mensagem
        };
        _notificacaoLista.Add(notificacao);
        return false;
    }

    public List<Notificacao> ObterNotificacoes()
    {
        return _notificacaoLista;
    }

    public bool TemNotificacao()
    {
        return _notificacaoLista.Any();
    }
}

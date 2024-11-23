using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invio.Domain.Entities;

namespace Invio.Domain.Logs;
public class Log
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required Guid UsuarioId { get; set; }
    public required string Acao { get; set; }
    public required string EntidadeAfetada { get; set; }
    public DateTime Data { get; set; } = DateTime.UtcNow;

    public Log() { }


    public Log(Guid usuarioId, string acao, string entidadeAfetada)
    {
        UsuarioId = usuarioId;
        Acao = acao;
        EntidadeAfetada = entidadeAfetada;
    }

    public override string ToString()
    {
        return $"{Data:yyyy-MM-dd HH:mm:ss} - Usuário ID: {UsuarioId} - Ação: {Acao} - Entidade: {EntidadeAfetada}";
    }
}

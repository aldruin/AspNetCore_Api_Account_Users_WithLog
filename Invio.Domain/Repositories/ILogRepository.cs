using Invio.Domain.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Domain.Repositories;
public interface ILogRepository : IRepository<Log>
{
    Task<IEnumerable<Log>> ObterPorUsuarioIdAsync(Guid usuarioId);
    Task<IEnumerable<Log>> ObterLogsAsync(DateTime dataInicio, DateTime dataFim);
}

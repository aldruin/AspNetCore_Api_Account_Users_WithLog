using Invio.Domain.Entities;
using Invio.Domain.Logs;
using Invio.Domain.Repositories;
using Invio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Infrastructure.Repositories;
public class LogRepository : Repository<Log>, ILogRepository
{
    public LogRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Log>> ObterPorUsuarioIdAsync(Guid usuarioId)
    {
        return await Query.Where(log => log.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<IEnumerable<Log>> ObterLogsAsync(DateTime dataInicio, DateTime dataFim)
    {
        return await Query.Where(log => log.Data >= dataInicio && log.Data <= dataFim).ToListAsync();
    }
}

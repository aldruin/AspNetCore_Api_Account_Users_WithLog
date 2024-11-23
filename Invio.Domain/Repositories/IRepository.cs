using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Domain.Repositories;
public interface IRepository<T> where T : class
{
    Task<T> ObterPorIdAsync(Guid? id);
    Task<ICollection<T>> ObterTodosAsync();
    Task AdicionarAsync(T entity);
    Task AtualizarAsync(T entity);
    Task RemoverPorIdAsync(Guid id);
    Task<bool> ExisteAsync(Expression<Func<T, bool>> expressao);
}

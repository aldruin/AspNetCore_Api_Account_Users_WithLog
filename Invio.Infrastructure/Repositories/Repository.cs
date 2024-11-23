using Invio.Domain.Repositories;
using Invio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Infrastructure.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    protected DbSet<T> Query { get; set; }
    protected DbContext Context { get; set; }

    public Repository(AppDbContext context)
    {
        Context = context;
        Query = Context.Set<T>();
    }

    public async Task<T> ObterPorIdAsync(Guid? id)
    {
        return await Query.FindAsync(id);
    }

    public async Task<ICollection<T>> ObterTodosAsync()
    {
        try
        {
            var consulta = await Query.ToListAsync();
            return consulta;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task AdicionarAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "A entidade não pode ser nula");
        await Query.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(T entity)
    {
        Query.Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task RemoverPorIdAsync(Guid id)
    {
        var entity = await Query.FindAsync(id);
        Query.Remove(entity);
        await Context.SaveChangesAsync();
    }

    public Task<bool> ExisteAsync(Expression<Func<T, bool>> expressao)
    {
        return Query.AnyAsync(expressao);
    }
}
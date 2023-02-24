using System.Linq.Expressions;
using BAS24.Libs.CQRS.Queries;
using BAS24.Libs.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Infra.Postgres;

public class PostgresRepository<TTable> : IPostgresRepository<TTable> where TTable : BasePostgresTable
{
  public PostgresRepository(PostgresDbContext context)
  {
    Context = context;
  }

  public PostgresDbContext Context { get; }

  public async Task<TTable> AddAsync(TTable entity)
  {
    Context.Set<TTable>().Add(entity);
    await Context.SaveChangesAsync();

    return entity;
  }

  public Task<int> DeleteAsync(Guid id)
  {
    return DeleteAsync(x => x.Id == id);
  }

  public Task<int> DeleteAsync(TTable entity)
  {
    Context.Set<TTable>().Remove(entity);
    return Context.SaveChangesAsync();
  }

  public Task<TTable?> FirstOrDefaultAsync(Guid id)
  {
    return Context.Set<TTable>().FindAsync(id).AsTask();
  }

  public Task UpdateAsync(TTable entity)
  {
    Context.Entry(entity).State = EntityState.Modified;
    Context.Set<TTable>().Update(entity);
    return Context.SaveChangesAsync();
  }

  public Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate, TQuery query)
    where TQuery : IPagedQuery
  {
    return Context.Set<TTable>().AsQueryable().Where(predicate).AsNoTracking().PaginateAsync(query);
  }

  public Task<PagedResult<TTable>> BrowseDescAsync<TQuery>(Expression<Func<TTable, bool>> predicate,
    Expression<Func<TTable, object>> order,
    TQuery query) where TQuery : IPagedQuery
  {
    return Context.Set<TTable>().AsQueryable().Where(predicate).OrderByDescending(order).AsNoTracking()
      .PaginateAsync(query);
  }

  public Task<int> DeleteAsync(Expression<Func<TTable, bool>> predicate)
  {
    var collection = Context.Set<TTable>().Where(predicate);
    Context.Set<TTable>().RemoveRange(collection);

    return Context.SaveChangesAsync();
  }

  public Task<bool> ExistsAsync(Expression<Func<TTable, bool>> predicate)
  {
    return Context.Set<TTable>().AnyAsync(predicate);
  }

  public async Task<IEnumerable<TTable>> WhereAsync(Expression<Func<TTable, bool>> predicate)
  {
    return await Context.Set<TTable>().Where(predicate).AsNoTracking().ToListAsync();
  }

  public Task<TTable?> FirstOrDefaultAsync(Expression<Func<TTable, bool>> predicate)
  {
    return Context.Set<TTable>().Where(predicate).AsNoTracking().FirstOrDefaultAsync();
  }

  public Task<int> CountAsync(Expression<Func<TTable, bool>> predicate)
  {
    return Context.Set<TTable>().Where(predicate).CountAsync();
  }

  public Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate,
    Expression<Func<TTable, object>> order,
    TQuery query) where TQuery : IPagedQuery
  {
    return Context.Set<TTable>().AsQueryable().Where(predicate).OrderBy(order).AsNoTracking().PaginateAsync(query);
  }
}

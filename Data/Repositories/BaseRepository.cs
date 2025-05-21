using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected BaseRepository(DataContext context, DbSet<TEntity> dbSet)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<bool> AddEntityAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error adding entity: {ex.Message}");
            return false;
        }
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeExpression = null)
    {
        try
        {
            IQueryable<TEntity> query = _dbSet;
            if (includeExpression != null)
                query = includeExpression(query);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return [];
        }
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(expression) ?? throw new Exception("Not found.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null!;
        }
    }
}

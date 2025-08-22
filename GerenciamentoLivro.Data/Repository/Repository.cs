using GerenciamentoLivro.Data.Context;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GerenciamentoLivro.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly GerenciamentoLivroDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(GerenciamentoLivroDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> ObterQueryable()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual IQueryable<TEntity> Filtrar(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public virtual async Task<TEntity?> ObterPorIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<bool> ExisteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public virtual async Task AdicionarAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task AtualizarAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task RemoverAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync();
            }
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

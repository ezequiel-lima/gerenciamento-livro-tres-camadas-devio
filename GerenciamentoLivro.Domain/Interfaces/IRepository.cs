using GerenciamentoLivro.Domain.Models;
using System.Linq.Expressions;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IQueryable<TEntity> ObterQueryable();
        IQueryable<TEntity> Filtrar(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> ObterPorIdAsync(Guid id);
        Task<bool> ExisteAsync(Expression<Func<TEntity, bool>> predicate);
        Task AdicionarAsync(TEntity entity);
        Task AtualizarAsync(TEntity entity);
        Task RemoverAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}

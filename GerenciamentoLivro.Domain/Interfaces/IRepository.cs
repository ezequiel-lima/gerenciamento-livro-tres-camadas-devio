using GerenciamentoLivro.Domain.Models;
using System.Linq.Expressions;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<ResultadoPaginado<TEntity>> ObterPaginado(int numeroPagina = 0, int tamanhoPagina = 12);
        Task<bool> Existe(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}

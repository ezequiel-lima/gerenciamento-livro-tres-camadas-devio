using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        Task<int> ContarEmprestimosAtivosPorUsuario(Guid idUsuario);
        Task<IEnumerable<Emprestimo>> ObterEmprestimosAtivosPorUsuario(Guid idUsuario);
    }
}

using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        Task<IEnumerable<Emprestimo>> ObterEmprestimosAtivosEVencidosPorUsuario(Guid idUsuario);
    }
}

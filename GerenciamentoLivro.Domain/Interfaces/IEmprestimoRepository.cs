using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        IQueryable<Emprestimo> ObterAtivosPorUsuario(Guid idUsuario);
        IQueryable<Emprestimo> ObterComLivroEUsuario();
        IQueryable<Emprestimo> ObterEmprestimosAtrasados();
    }
}

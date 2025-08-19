using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface IEmprestimoService
    {
        Task Adicionar(Emprestimo emprestimo);
        Task<IEnumerable<Emprestimo>> ObterEmprestimosAtivosPorUsuario(Guid idUsuario);
        Task<ResultadoPaginado<Emprestimo>> ObterEmprestimosPaginados(int numeroPagina = 0, int tamanhoPagina = 12);
    }
}

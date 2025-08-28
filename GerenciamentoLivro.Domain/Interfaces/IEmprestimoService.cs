using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface IEmprestimoService
    {
        Task Adicionar(Emprestimo emprestimo);
        Task<ResultadoPaginado<Emprestimo>> ObterEmprestimosPaginados(int numeroPagina = 0, int tamanhoPagina = 12);
        Task<ResultadoPaginado<Emprestimo>> ObterEmprestimosAtrasadosPaginados(int numeroPagina = 0, int tamanhoPagina = 12);
        Task<IEnumerable<Emprestimo>> ObterEmprestimosAtivos(Guid idUsuario);
    }
}

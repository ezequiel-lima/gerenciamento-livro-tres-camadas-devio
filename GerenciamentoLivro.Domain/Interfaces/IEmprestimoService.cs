using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface IEmprestimoService
    {
        Task Adicionar(Emprestimo emprestimo);
    }
}

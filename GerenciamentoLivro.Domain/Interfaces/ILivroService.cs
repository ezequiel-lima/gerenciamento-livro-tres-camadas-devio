using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> ObterTodos();
    }
}

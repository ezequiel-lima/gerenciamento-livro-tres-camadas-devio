using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<Livro?> BuscarLivros(string titulo);
    }
}

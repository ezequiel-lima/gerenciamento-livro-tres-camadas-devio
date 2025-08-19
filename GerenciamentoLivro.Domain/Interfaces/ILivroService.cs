using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> BuscarLivros(string? titulo);
        Task Adicionar(Livro livro);
        Task Remover(Guid id);
        Task Update(Guid id, Livro livro);
    }
}

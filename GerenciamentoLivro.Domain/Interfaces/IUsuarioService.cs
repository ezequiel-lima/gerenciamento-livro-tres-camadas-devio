using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task Adicionar(Usuario usuario);
    }
}

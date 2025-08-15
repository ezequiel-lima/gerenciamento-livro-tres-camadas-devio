using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Services
{
    public class LivroService : BaseService, ILivroService
    {
        private readonly ILivroRepository _repository;

        public LivroService(INotificador notificador, ILivroRepository repository) : base(notificador)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Livro>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }
    }
}

using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Services
{
    public class LivroService : BaseService, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(INotificador notificador, ILivroRepository repository) : base(notificador)
        {
            _livroRepository = repository;
        }

        public async Task<IEnumerable<Livro>> ObterTodos()
        {
            return await _livroRepository.ObterTodos();
        }

        public async Task<Livro?> ObterLivro(string titulo)
        {
            return await _livroRepository.ObterLivro(titulo);
        }

        public async Task Adicionar(Livro livro)
        {
            await _livroRepository.Adicionar(livro);
        }

        public async Task Update(Guid id, Livro livro)
        {
            var livroParaAtualizacao = await _livroRepository.ObterPorId(id);

            if (livroParaAtualizacao is null)
            {
                Notificar("Livro não encontrado");
                return;
            }

            livroParaAtualizacao.AtualizarDados(livro.Titulo, livro.Autor, livro.Isbn, livro.DataDePublicacao);

            await _livroRepository.Atualizar(livroParaAtualizacao);
        }

        public async Task Remover(Guid id)
        {
            await _livroRepository.Remover(id);
        }
    }
}

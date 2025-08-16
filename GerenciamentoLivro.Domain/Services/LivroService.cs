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

        public async Task<Livro?> ObterLivro(string titulo)
        {
            return await _repository.ObterLivro(titulo);
        }

        public async Task Adicionar(Livro livro)
        {
            await _repository.Adicionar(livro);
        }

        public async Task Update(Guid id, Livro livro)
        {
            var livroParaAtualizacao = await _repository.ObterPorId(id);

            if (livroParaAtualizacao is null)
            {
                Notificar("Livro não encontrado");
                return;
            }

            livroParaAtualizacao.Titulo = livro.Titulo;
            livroParaAtualizacao.Autor = livro.Autor;
            livroParaAtualizacao.Isbn = livro.Isbn;
            livroParaAtualizacao.DataDePublicacao = livro.DataDePublicacao;

            await _repository.Atualizar(livroParaAtualizacao);
        }

        public async Task Remover(Guid id)
        {
            await _repository.Remover(id);
        }
    }
}

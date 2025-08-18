using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using GerenciamentoLivro.Domain.Validations;

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
            if (!ValidarEntidade(livro, new LivroValidation()))
                return;

            if (await _livroRepository.Existe(x => x.Isbn == livro.Isbn))
            {
                Notificar("Já existe um livro com este Isbn informado.");
                return;
            }

            await _livroRepository.Adicionar(livro);
        }

        public async Task Update(Guid id, Livro livro)
        {
            if (!ValidarEntidade(livro, new LivroValidation()))
                return;

            if (await _livroRepository.Existe(x => x.Isbn == livro.Isbn && x.Id != id))
            {
                Notificar("Já existe um livro com este Isbn informado.");
                return;
            }

            var livroExistente = await _livroRepository.ObterPorId(id);

            if (livroExistente is null)
            {
                Notificar("Livro não encontrado");
                return;
            }

            livroExistente.AtualizarDados(livro.Titulo, livro.Autor, livro.Isbn, livro.DataDePublicacao);

            await _livroRepository.Atualizar(livroExistente);
        }

        public async Task Remover(Guid id)
        {
            await _livroRepository.Remover(id);
        }
    }
}

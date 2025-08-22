using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using GerenciamentoLivro.Domain.Validations;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoLivro.Domain.Services
{
    public class LivroService : BaseService, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(INotificador notificador, ILivroRepository repository) : base(notificador)
        {
            _livroRepository = repository;
        }

        public async Task<IEnumerable<Livro>> BuscarLivros(string? titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                return await _livroRepository.ObterQueryable().ToListAsync();

            var livro = await _livroRepository.BuscarLivros(titulo);

            return livro is null
                ? Enumerable.Empty<Livro>()
                : new[] { livro };
        }

        public async Task Adicionar(Livro livro)
        {
            if (!ValidarEntidade(livro, new LivroValidation()))
                return;

            if (await _livroRepository.ExisteAsync(x => x.Isbn == livro.Isbn))
            {
                Notificar("Já existe um livro com este Isbn informado.");
                return;
            }

            await _livroRepository.AdicionarAsync(livro);
        }

        public async Task Update(Guid id, Livro livro)
        {
            if (!ValidarEntidade(livro, new LivroValidation()))
                return;

            if (await _livroRepository.ExisteAsync(x => x.Isbn == livro.Isbn && x.Id != id))
            {
                Notificar("Já existe um livro com este Isbn informado.");
                return;
            }

            var livroExistente = await _livroRepository.ObterPorIdAsync(id);

            if (livroExistente is null)
            {
                Notificar("Livro não encontrado");
                return;
            }

            livroExistente.AtualizarDados(livro.Titulo, livro.Autor, livro.Isbn, livro.DataDePublicacao);

            await _livroRepository.AtualizarAsync(livroExistente);
        }

        public async Task Remover(Guid id)
        {
            await _livroRepository.RemoverAsync(id);
        }
    }
}

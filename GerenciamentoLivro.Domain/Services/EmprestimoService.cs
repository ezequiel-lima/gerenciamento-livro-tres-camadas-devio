using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using GerenciamentoLivro.Domain.Validations;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoLivro.Domain.Services
{
    public class EmprestimoService : BaseService, IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private const int MaximoLivrosPermitidos = 3;

        public EmprestimoService(INotificador notificador, IEmprestimoRepository emprestimoRepository) : base(notificador)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<ResultadoPaginado<Emprestimo>> ObterEmprestimosPaginados(int numeroPagina = 0, int tamanhoPagina = 12)
        {
            var query = _emprestimoRepository.ObterComLivroEUsuario();

            var total = await query.CountAsync();
            var itens = await query
                .Skip(numeroPagina * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            return new ResultadoPaginado<Emprestimo>
            {
                Itens = itens,
                TotalItens = total,
                NumeroPagina = numeroPagina,
                TamanhoPagina = tamanhoPagina
            };
        }

        public async Task<ResultadoPaginado<Emprestimo>> ObterEmprestimosAtrasadosPaginados(int numeroPagina = 0, int tamanhoPagina = 12)
        {
            var query = _emprestimoRepository.ObterComLivroEUsuario()
                .Where(x => x.DataDevolucaoPrevista < DateTime.Now.Date && x.DataDevolucaoEfetiva == null);

            var total = await query.CountAsync();
            var itens = await query
                .Skip(numeroPagina * tamanhoPagina)
                .Take(tamanhoPagina)
                .OrderBy(x => x.IdUsuario)
                .ToListAsync();

            return new ResultadoPaginado<Emprestimo>
            {
                Itens = itens,
                TotalItens = total,
                NumeroPagina = numeroPagina,
                TamanhoPagina = tamanhoPagina
            };
        }

        public async Task<IEnumerable<Emprestimo>> ObterEmprestimosAtrasados()
        {
            var query = _emprestimoRepository.ObterEmprestimosAtrasados().OrderBy(x => x.IdUsuario);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Emprestimo>> ObterEmprestimosAtivos(Guid idUsuario)
        {
            var query = _emprestimoRepository.ObterAtivosPorUsuario(idUsuario);
            return await query.ToListAsync();
        }

        public async Task Adicionar(Emprestimo emprestimo)
        {
            if (!ValidarEntidade(emprestimo, new EmprestimoValidation()))
                return;

            if (await UsuarioJaAlugouEsteLivro(emprestimo))
            {
                Notificar("Você já alugou esse livro.");
                return;
            }

            var emprestimosAtivo = await _emprestimoRepository.ObterAtivosPorUsuario(emprestimo.IdUsuario).ToListAsync();
            var quantidadeEmprestimosAtivos = emprestimosAtivo.Count();

            if (UsuarioAtingiuLimiteDeLivros(quantidadeEmprestimosAtivos))
            {
                Notificar($"Você já atingiu o limite máximo de {MaximoLivrosPermitidos} livros alugados.");
                return;
            }

            var dataDevolucao = CalcularDataDevolucaoPorQuantidade(quantidadeEmprestimosAtivos + 1);

            emprestimo.DefinirDataDevolucaoPrevista(dataDevolucao);

            await AtualizarTodosOsEmprestimos(emprestimosAtivo, dataDevolucao);

            await _emprestimoRepository.AdicionarAsync(emprestimo);
        }

        private async Task AtualizarTodosOsEmprestimos(IEnumerable<Emprestimo> emprestimosAtivos, DateTime dataDevolucao)
        {
            foreach (var emprestimoAtivo in emprestimosAtivos)
            {
                emprestimoAtivo.DefinirDataDevolucaoPrevista(dataDevolucao);
                await _emprestimoRepository.AtualizarAsync(emprestimoAtivo);
            }
        }

        private async Task<bool> UsuarioJaAlugouEsteLivro(Emprestimo emprestimo)
        {
            return await _emprestimoRepository.ExisteAsync(x =>
                x.IdLivro == emprestimo.IdLivro &&
                x.IdUsuario == emprestimo.IdUsuario &&
                x.DataDevolucaoEfetiva == null);
        }

        private bool UsuarioAtingiuLimiteDeLivros(int emprestimosAtivos)
        {
            return emprestimosAtivos >= MaximoLivrosPermitidos;
        }

        private DateTime CalcularDataDevolucaoPorQuantidade(int totalLivrosEmprestados)
        {
            return totalLivrosEmprestados switch
            {
                1 => DateTime.Now.AddDays(30),
                2 => DateTime.Now.AddDays(15),
                3 => DateTime.Now.AddDays(7),
                _ => throw new InvalidOperationException("Número de livros inválido para empréstimo.")
            };
        }
    }
}

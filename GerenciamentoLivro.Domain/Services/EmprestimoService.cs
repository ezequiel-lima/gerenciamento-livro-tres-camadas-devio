using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using GerenciamentoLivro.Domain.Validations;

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
            return await _emprestimoRepository.ObterPaginado(numeroPagina, tamanhoPagina);
        }

        public async Task<IEnumerable<Emprestimo>> ObterEmprestimosAtivosPorUsuario(Guid idUsuario)
        {
            return await _emprestimoRepository.ObterEmprestimosAtivosPorUsuario(idUsuario);
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

            var emprestimosAtivos = await _emprestimoRepository.ObterEmprestimosAtivosPorUsuario(emprestimo.IdUsuario);
            var quantidadeEmprestimosAtivos = emprestimosAtivos.Count();

            if (UsuarioAtingiuLimiteDeLivros(quantidadeEmprestimosAtivos))
            {
                Notificar($"Você já atingiu o limite máximo de {MaximoLivrosPermitidos} livros alugados.");
                return;
            }

            var dataDevolucao = CalcularDataDevolucaoPorQuantidade(quantidadeEmprestimosAtivos + 1);

            emprestimo.DefinirDataDevolucaoPrevista(dataDevolucao);

            await AtualizarTodosOsEmprestimos(emprestimosAtivos, dataDevolucao);

            await _emprestimoRepository.Adicionar(emprestimo);
        }

        private async Task AtualizarTodosOsEmprestimos(IEnumerable<Emprestimo> emprestimosAtivos, DateTime dataDevolucao)
        {
            foreach (var emprestimoAtivo in emprestimosAtivos)
            {
                emprestimoAtivo.DefinirDataDevolucaoPrevista(dataDevolucao);
                await _emprestimoRepository.Atualizar(emprestimoAtivo);
            }
        }

        private async Task<bool> UsuarioJaAlugouEsteLivro(Emprestimo emprestimo)
        {
            return await _emprestimoRepository.Existe(x =>
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

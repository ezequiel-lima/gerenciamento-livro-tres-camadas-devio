using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using GerenciamentoLivro.Domain.Validations;

namespace GerenciamentoLivro.Domain.Services
{
    public class EmprestimoService : BaseService, IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly int _maximoDeDiasPermitidoParaDevolucao = 30;

        public EmprestimoService(INotificador notificador, IEmprestimoRepository emprestimoRepository) : base(notificador)
        {
            _emprestimoRepository = emprestimoRepository;
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

            var dataDevolucao = CalcularDataDevolucao(emprestimosAtivos);

            emprestimo.DefinirDataDevolucaoPrevista(dataDevolucao);

            await _emprestimoRepository.Adicionar(emprestimo);
        }

        private async Task<bool> UsuarioJaAlugouEsteLivro(Emprestimo emprestimo)
        {
            return await _emprestimoRepository.Existe(x =>
                x.IdLivro == emprestimo.IdLivro &&
                x.IdUsuario == emprestimo.IdUsuario &&
                x.DataDevolucaoEfetiva == null);
        }

        private DateTime CalcularDataDevolucao(IEnumerable<Emprestimo> emprestimosAtivos)
        {
            var primeiroEmprestimo = emprestimosAtivos
                .OrderBy(e => e.DataDeEmprestimo)
                .FirstOrDefault();

            var dataLimite = primeiroEmprestimo?.DataDevolucaoPrevista
                             ?? DateTime.Now.AddDays(_maximoDeDiasPermitidoParaDevolucao);

            var quantidadeDeEmprestimos = emprestimosAtivos.Count();
            var prazoIdealEmDias = _maximoDeDiasPermitidoParaDevolucao / (quantidadeDeEmprestimos + 1);
            var dataIdeal = DateTime.Now.AddDays(prazoIdealEmDias);

            return dataIdeal > dataLimite ? dataLimite : dataIdeal;
        }
    }
}

using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Services
{
    public class EmprestimoService : BaseService, IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public EmprestimoService(INotificador notificador, IEmprestimoRepository emprestimoRepository) : base(notificador)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task Adicionar(Emprestimo emprestimo)
        {
            await _emprestimoRepository.Adicionar(emprestimo);
        }
    }
}

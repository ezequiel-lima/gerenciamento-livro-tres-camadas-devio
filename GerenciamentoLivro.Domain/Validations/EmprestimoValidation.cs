using FluentValidation;
using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Validations
{
    public class EmprestimoValidation : AbstractValidator<Emprestimo>
    {
        public EmprestimoValidation()
        {
            RuleFor(e => e.IdUsuario)
                .NotEqual(Guid.Empty).WithMessage("Usuário inválido.");

            RuleFor(e => e.IdLivro)
                .NotEqual(Guid.Empty).WithMessage("Livro inválido.");

            RuleFor(e => e.DataEmprestimo)
                .LessThan(DateTime.Now).WithMessage("A data de empréstimo não pode ser no futuro.");
        }
    }
}

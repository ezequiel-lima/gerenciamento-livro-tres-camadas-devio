using FluentValidation;
using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .Length(2, 250).WithMessage("O nome deve ter entre 2 e 250 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail do usuário é obrigatório.")
                .MaximumLength(250).WithMessage("O e-mail deve ter no máximo 250 caracteres.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");
        }
    }
}

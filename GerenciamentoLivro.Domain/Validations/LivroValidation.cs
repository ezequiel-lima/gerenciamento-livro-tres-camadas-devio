using FluentValidation;
using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Domain.Validations
{
    public class LivroValidation : AbstractValidator<Livro>
    {
        public LivroValidation()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título do livro é obrigatório.")
                .MaximumLength(200).WithMessage("O título deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Autor)
                .NotEmpty().WithMessage("O autor do livro é obrigatório.")
                .MaximumLength(250).WithMessage("O nome do autor deve ter no máximo 250 caracteres.");

            RuleFor(x => x.Isbn)
                .NotEmpty().WithMessage("O ISBN do livro é obrigatório.")
                .MaximumLength(17).WithMessage("O ISBN deve ter no máximo 17 caracteres.")
                .Matches(@"^\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$").WithMessage("O ISBN deve estar em um formato válido (ex: 978-3-16-148410-0).");

            RuleFor(x => x.DataDePublicacao)
                .NotEmpty().WithMessage("A data de publicação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("A data de publicação não pode ser no futuro.");
        }
    }
}

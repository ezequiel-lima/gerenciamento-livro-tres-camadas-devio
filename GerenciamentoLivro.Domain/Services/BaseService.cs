using FluentValidation;
using FluentValidation.Results;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using GerenciamentoLivro.Domain.Notifications;

namespace GerenciamentoLivro.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notificar(item.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handler(new Notificacao(mensagem));
        }

        protected bool ValidarEntidade<TValidation, TEntity>(TEntity entidade, TValidation validacao)
            where TEntity : Entity
            where TValidation : AbstractValidator<TEntity>
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
                return true;

            Notificar(validator);

            return false;
        }
    }
}

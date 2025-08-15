using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace GerenciamentoLivro.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
        {
            if (OperacaoValida())
            {
                return new ObjectResult(result)
                {
                    StatusCode = Convert.ToInt32(statusCode)
                };
            }

            return BadRequest(new
            {
                erros = _notificador.ObterNotificacoes().Select(x => x.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotificarErroModelInvalida(modelState);

            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(x => x.Errors);

            foreach (var erro in erros)
            {
                // Verifica se a mensagem de erro vem de uma exceção ou de outra origem.
                // Se 'Exception' for nula, significa que o erro foi gerado manualmente, então usamos 'ErrorMessage'.
                // Caso contrário, extraímos a mensagem da exceção lançada.
                // Isso é necessário para garantir que a mensagem de erro seja corretamente capturada e notificada.
                var errorMsg = erro.Exception is null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handler(new Notificacao(mensagem));
        }
    }
}

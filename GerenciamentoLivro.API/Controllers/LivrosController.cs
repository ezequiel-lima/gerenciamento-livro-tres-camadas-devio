using GerenciamentoLivro.API.Dtos.Responses;
using GerenciamentoLivro.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GerenciamentoLivro.API.Controllers
{
    [Route("api/[controller]")]
    public class LivrosController : MainController
    {
        private readonly ILivroService _livroService;

        public LivrosController(INotificador notificador, ILivroService livroService) : base(notificador)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroResponse>>> ObterTodos()
        {
            var livros = await _livroService.ObterTodos();
            var response = livros.Select(x => (LivroResponse)x);
            return CustomResponse(HttpStatusCode.OK, response);
        }
    }
}

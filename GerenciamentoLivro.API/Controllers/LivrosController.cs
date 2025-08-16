using GerenciamentoLivro.API.Dtos.Requests;
using GerenciamentoLivro.API.Dtos.Responses;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
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

        [HttpGet("buscar")]
        public async Task<ActionResult<LivroResponse>> ObterLivro(string titulo)
        {
            var livro = await _livroService.ObterLivro(titulo);

            if (livro is null)
                return NotFound();

            var response = (LivroResponse)livro;

            return CustomResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarLivro(CreateLivroRequest request)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var livro = (Livro)request;
            await _livroService.Adicionar(livro);

            var response = (LivroResponse)livro;

            return CustomResponse(HttpStatusCode.Created, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> AtualizarLivro(Guid id, UpdateLivroRequest request)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var livro = (Livro)request;
            await _livroService.Update(id, livro);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletarLivro(Guid id)
        {
            await _livroService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
    }
}

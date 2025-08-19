using GerenciamentoLivro.API.Dtos.Requests;
using GerenciamentoLivro.API.Dtos.Responses;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GerenciamentoLivro.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEmprestimoService _emprestimoService;

        public UsuariosController(INotificador notificador, IUsuarioService usuarioService, IEmprestimoService serviceEmprestimo) : base(notificador)
        {
            _usuarioService = usuarioService;
            _emprestimoService = serviceEmprestimo;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario(CreateUsuarioRequest request)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var usuario = (Usuario)request;
            await _usuarioService.Adicionar(usuario);

            var response = (UsuarioResponse)usuario;
            return CustomResponse(HttpStatusCode.Created, response);
        }

        [HttpGet("{id:guid}/emprestimos")]
        public async Task<ActionResult<EmprestimoResponse>> ObterEmprestimosAtivosPorUsuario(Guid id)
        {
            var emprestimos = await _emprestimoService.ObterEmprestimosAtivosPorUsuario(id);

            if (emprestimos == null || !emprestimos.Any())
                return CustomResponse(HttpStatusCode.NotFound);

            var response = emprestimos.Select(e => (EmprestimoResponse)e);
            return CustomResponse(HttpStatusCode.OK, response);
        }
    }
}

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

        public UsuariosController(INotificador notificador, IUsuarioService usuarioService) : base(notificador)
        {
            _usuarioService = usuarioService;
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
    }
}

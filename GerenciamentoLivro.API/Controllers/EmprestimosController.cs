using GerenciamentoLivro.API.Dtos.Requests;
using GerenciamentoLivro.API.Dtos.Responses;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GerenciamentoLivro.API.Controllers
{
    [Route("api/[controller]")]
    public class EmprestimosController : MainController
    {
        private readonly IEmprestimoService _serviceEmprestimo;

        public EmprestimosController(INotificador notificador, IEmprestimoService serviceEmprestimo) : base(notificador)
        {
            _serviceEmprestimo = serviceEmprestimo;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEmprestimo(CreateEmprestimoRequest request)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var emprestimo = (Emprestimo)request;
            await _serviceEmprestimo.Adicionar(emprestimo);

            var response = (EmprestimoResponse)emprestimo;
            return CustomResponse(HttpStatusCode.Created, response);
        }
    }
}

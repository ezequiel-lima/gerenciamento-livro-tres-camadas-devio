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
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimosController(INotificador notificador, IEmprestimoService serviceEmprestimo) : base(notificador)
        {
            _emprestimoService = serviceEmprestimo;
        }

        [HttpGet]
        public async Task<ActionResult<ResultadoPaginado<EmprestimoResponse>>> ObterEmprestimosPaginados(
            int numeroPagina = 0, 
            int tamanhoPagina = 12)
        {
            var emprestimos = await _emprestimoService.ObterEmprestimosPaginados(numeroPagina, tamanhoPagina);

            if (emprestimos is null || !emprestimos.Itens.Any())
                return CustomResponse(HttpStatusCode.NotFound);

            var response = new ResultadoPaginado<EmprestimoResponse>
            {
                Itens = emprestimos.Itens.Select(e => (EmprestimoResponse)e),
                TotalItens = emprestimos.TotalItens,
                NumeroPagina = emprestimos.NumeroPagina,
                TamanhoPagina = emprestimos.TamanhoPagina
            };

            return CustomResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEmprestimo(CreateEmprestimoRequest request)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var emprestimo = (Emprestimo)request;
            await _emprestimoService.Adicionar(emprestimo);

            var response = (CreateEmprestimoResponse)emprestimo;
            return CustomResponse(HttpStatusCode.Created, response);
        }
    }
}

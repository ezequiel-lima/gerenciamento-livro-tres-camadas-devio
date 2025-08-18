using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.API.Dtos.Requests
{
    public class CreateEmprestimoRequest
    {
        public Guid IdUsuario { get; set; }
        public Guid IdLivro { get; set; }

        public static explicit operator Emprestimo(CreateEmprestimoRequest request)
        {
            return new Emprestimo(request.IdUsuario, request.IdLivro);
        }
    }
}

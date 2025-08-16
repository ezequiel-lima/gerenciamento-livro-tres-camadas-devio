using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.API.Dtos.Requests
{
    public class CreateUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public static explicit operator Usuario(CreateUsuarioRequest request)
        {
            return new Usuario(request.Nome, request.Email);
        }
    }
}

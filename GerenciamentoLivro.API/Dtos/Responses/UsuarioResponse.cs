using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.API.Dtos.Responses
{
    public class UsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static explicit operator UsuarioResponse(Usuario usuario)
        {
            return new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }
    }
}

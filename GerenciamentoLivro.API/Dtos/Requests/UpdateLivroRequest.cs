using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.API.Dtos.Requests
{
    public class UpdateLivroRequest
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public DateTime DataDePublicacao { get; set; }

        public static explicit operator Livro(UpdateLivroRequest request)
        {
            return new Livro(request.Titulo, request.Autor, request.Isbn, request.DataDePublicacao);
        }
    }
}

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
            return new Livro
            {
                Titulo = request.Titulo,
                Autor = request.Autor,
                Isbn = request.Isbn,
                DataDePublicacao = request.DataDePublicacao
            };
        }
    }
}

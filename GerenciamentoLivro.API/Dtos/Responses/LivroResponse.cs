using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.API.Dtos.Responses
{
    public class LivroResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public DateTime DataDePublicacao { get; set; }

        public static explicit operator LivroResponse(Livro livro)
        {
            return new LivroResponse
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Isbn = livro.Isbn,
                DataDePublicacao = livro.DataDePublicacao
            };
        }
    }
}

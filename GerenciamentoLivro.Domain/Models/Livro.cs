namespace GerenciamentoLivro.Domain.Models
{
    public class Livro : Entity
    {
        protected Livro() { }

        public Livro(string titulo, string autor, string isbn, DateTime dataDePublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            DataDePublicacao = dataDePublicacao;
        }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public DateTime DataDePublicacao { get; set; }

        public void AtualizarDados(string titulo, string autor, string isbn, DateTime dataPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            DataDePublicacao = dataPublicacao;
        }
    }
}

namespace GerenciamentoLivro.Domain.Models
{
    public class Livro : Entity
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public DateTime DataDePublicacao { get; set; }
    }
}

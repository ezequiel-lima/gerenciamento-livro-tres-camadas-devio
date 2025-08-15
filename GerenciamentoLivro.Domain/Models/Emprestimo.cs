namespace GerenciamentoLivro.Domain.Models
{
    public class Emprestimo : Entity
    {
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public Guid IdLivro { get; set; }
        public Livro Livro { get; set; }

        public DateTime DataDeEmprestimo { get; set; } = DateTime.Now;
    }
}

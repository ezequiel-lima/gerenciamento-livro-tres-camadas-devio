namespace GerenciamentoLivro.Domain.Models
{
    public class Emprestimo : Entity
    {
        protected Emprestimo() { }

        public Emprestimo(Guid idUsuario, Guid idLivro)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataDeEmprestimo = DateTime.Now;
        }

        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public Guid IdLivro { get; set; }
        public Livro Livro { get; set; }

        public DateTime DataDeEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoEfetiva { get; set; }

        public void DefinirDataDevolucaoPrevista(DateTime dataDevolucao)
        {
            DataDevolucaoPrevista = dataDevolucao;
        }
    }
}

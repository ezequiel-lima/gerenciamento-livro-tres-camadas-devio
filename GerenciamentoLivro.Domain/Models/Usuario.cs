namespace GerenciamentoLivro.Domain.Models
{
    public class Usuario : Entity
    {
        protected Usuario() { }

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
    }
}

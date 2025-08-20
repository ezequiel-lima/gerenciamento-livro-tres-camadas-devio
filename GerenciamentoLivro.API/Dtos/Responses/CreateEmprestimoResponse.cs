using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.API.Dtos.Responses
{
    public class CreateEmprestimoResponse
    {
        public Guid IdUsuario { get; set; }
        public Guid IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }

        public static explicit operator CreateEmprestimoResponse(Emprestimo emprestimo)
        {
            return new CreateEmprestimoResponse
            {
                IdUsuario = emprestimo.IdUsuario,
                IdLivro = emprestimo.IdLivro,
                DataEmprestimo = emprestimo.DataEmprestimo,
                DataDevolucaoPrevista = emprestimo.DataDevolucaoPrevista
            };
        }
    }
}

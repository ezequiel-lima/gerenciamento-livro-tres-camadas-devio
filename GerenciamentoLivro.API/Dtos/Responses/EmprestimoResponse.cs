using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.API.Dtos.Responses
{
    public class EmprestimoResponse
    {
        public Guid IdUsuario { get; set; }
        public Guid IdLivro { get; set; }
        public DateTime DataDeEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoEfetiva { get; set; }


        public static explicit operator EmprestimoResponse(Emprestimo emprestimo)
        {
            return new EmprestimoResponse
            {
                IdUsuario = emprestimo.IdUsuario,
                IdLivro = emprestimo.IdLivro,
                DataDeEmprestimo = emprestimo.DataDeEmprestimo,
                DataDevolucaoPrevista = emprestimo.DataDevolucaoPrevista,
                DataDevolucaoEfetiva = emprestimo.DataDevolucaoEfetiva
            };
        }
    }
}

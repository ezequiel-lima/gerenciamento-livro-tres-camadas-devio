using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.API.Dtos.Responses
{
    public class EmprestimoResponse
    {
        public Guid IdUsuario { get; set; }
        public string? NomeUsuario { get; set; }
        public Guid IdLivro { get; set; }
        public string? TituloLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoEfetiva { get; set; }


        public static explicit operator EmprestimoResponse(Emprestimo emprestimo)
        {
            return new EmprestimoResponse
            {
                IdUsuario = emprestimo.IdUsuario,
                NomeUsuario = emprestimo.Usuario?.Nome,
                IdLivro = emprestimo.IdLivro,
                TituloLivro = emprestimo.Livro?.Titulo,
                DataEmprestimo = emprestimo.DataEmprestimo,
                DataDevolucaoPrevista = emprestimo.DataDevolucaoPrevista,
                DataDevolucaoEfetiva = emprestimo.DataDevolucaoEfetiva
            };
        }
    }
}

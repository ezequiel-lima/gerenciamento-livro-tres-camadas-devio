using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.API.Dtos.Responses
{
    public class EmprestimoAtrasadoResponse
    {
        public Guid IdUsuario { get; set; }
        public string? NomeUsuario { get; set; }
        public string? TituloLivro { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }


        public static explicit operator EmprestimoAtrasadoResponse(Emprestimo emprestimo)
        {
            return new EmprestimoAtrasadoResponse
            {
                IdUsuario = emprestimo.IdUsuario,
                NomeUsuario = emprestimo.Usuario?.Nome,
                TituloLivro = emprestimo.Livro?.Titulo,
                DataDevolucaoPrevista = emprestimo.DataDevolucaoPrevista
            };
        }
    }
}

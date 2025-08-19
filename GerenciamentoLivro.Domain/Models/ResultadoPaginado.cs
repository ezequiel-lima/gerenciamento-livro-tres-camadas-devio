namespace GerenciamentoLivro.Domain.Models
{
    public class ResultadoPaginado<T>
    {
        public IEnumerable<T> Itens { get; set; }
        public int TotalItens { get; set; }
        public int NumeroPagina { get; set; }
        public int TamanhoPagina { get; set; }
    }
}

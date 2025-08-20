using GerenciamentoLivro.Data.Context;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoLivro.Data.Repository
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(GerenciamentoLivroDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<ResultadoPaginado<Emprestimo>> ObterPaginado(int numeroPagina = 0, int tamanhoPagina = 12)
        {
            var totalItens = await _dbSet.CountAsync();
            var itens = await _dbSet
                .AsNoTracking()
                .Include(x => x.Livro)
                .Include(x => x.Usuario)
                .Skip(numeroPagina * tamanhoPagina) 
                .Take(tamanhoPagina)
                .ToListAsync();

            return new ResultadoPaginado<Emprestimo>
            {
                Itens = itens,
                TotalItens = totalItens,
                NumeroPagina = numeroPagina,
                TamanhoPagina = tamanhoPagina
            };
        }

        public async Task<IEnumerable<Emprestimo>> ObterEmprestimosAtivosEVencidosPorUsuario(Guid idUsuario)
        {
            return await _dbSet
                .Include(x => x.Livro)
                .Include(x => x.Usuario)
                .Where(x => x.IdUsuario == idUsuario &&
                    x.DataDevolucaoEfetiva == null)
                .ToListAsync();
        }
    }
}

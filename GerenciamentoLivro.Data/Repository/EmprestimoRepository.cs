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

        public async Task<int> ContarEmprestimosAtivosPorUsuario(Guid idUsuario)
        {
            return await _dbSet.Where(x => x.IdUsuario == idUsuario && x.DataDevolucaoPrevista >= DateTime.Now).CountAsync();
        }

        public async Task<IEnumerable<Emprestimo>> ObterEmprestimosAtivosPorUsuario(Guid idUsuario)
        {
            return await _dbSet.Where(x => x.IdUsuario == idUsuario && x.DataDevolucaoPrevista >= DateTime.Now).ToListAsync();
        }
    }
}

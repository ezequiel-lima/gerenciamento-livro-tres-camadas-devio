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

        public IQueryable<Emprestimo> ObterComLivroEUsuario()
        {
            return _dbSet
                .AsNoTracking()
                .Include(x => x.Livro)
                .Include(x => x.Usuario);
        }

        public IQueryable<Emprestimo> ObterAtivosPorUsuario(Guid idUsuario)
        {
            return _dbSet
                .AsNoTracking()
                .Include(x => x.Livro)
                .Include(x => x.Usuario)
                .Where(x => x.IdUsuario == idUsuario && x.DataDevolucaoEfetiva == null);
        }
    }
}

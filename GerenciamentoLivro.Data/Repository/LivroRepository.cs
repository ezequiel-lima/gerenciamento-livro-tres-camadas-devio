using GerenciamentoLivro.Data.Context;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoLivro.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(GerenciamentoLivroDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Livro?> ObterLivro(string titulo)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Titulo == titulo);
        }
    }
}

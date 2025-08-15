using GerenciamentoLivro.Data.Context;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(GerenciamentoLivroDbContext dbContext) : base(dbContext)
        {
        }
    }
}

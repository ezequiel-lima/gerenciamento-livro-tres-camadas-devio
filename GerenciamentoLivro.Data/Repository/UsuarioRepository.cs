using GerenciamentoLivro.Data.Context;
using GerenciamentoLivro.Domain.Interfaces;
using GerenciamentoLivro.Domain.Models;

namespace GerenciamentoLivro.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(GerenciamentoLivroDbContext dbContext) : base(dbContext)
        {
        }
    }
}

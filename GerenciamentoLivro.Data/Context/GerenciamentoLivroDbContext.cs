using GerenciamentoLivro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoLivro.Data.Context
{
    public class GerenciamentoLivroDbContext : DbContext
    {
        public GerenciamentoLivroDbContext(DbContextOptions<GerenciamentoLivroDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties()
                .Where(y => y.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(200)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GerenciamentoLivroDbContext).Assembly);

            // Configura o comportamento de exclusão para todas as chaves estrangeiras do modelo, definindo como ClientSetNull.
            // Por exemplo, ao excluir um fornecedor, os produtos relacionados não serão excluídos automaticamente,
            // Prevenindo a exclusão em cascata.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

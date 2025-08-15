using GerenciamentoLivro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoLivro.Data.Mappings
{
    public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataDeEmprestimo)
                   .IsRequired();

            builder.HasOne(x => x.Usuario)
                   .WithMany()
                   .HasForeignKey(x => x.IdUsuario);

            builder.HasOne(x => x.Livro)
                   .WithMany()
                   .HasForeignKey(x => x.IdLivro);

            builder.ToTable("Emprestimos");
        }
    }
}

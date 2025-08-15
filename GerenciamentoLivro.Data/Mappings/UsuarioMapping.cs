using GerenciamentoLivro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoLivro.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.ToTable("Usuarios");
        }
    }
}

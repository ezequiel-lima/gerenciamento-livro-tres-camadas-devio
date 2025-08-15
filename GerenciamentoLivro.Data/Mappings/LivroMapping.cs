using GerenciamentoLivro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoLivro.Data.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired();

            builder.Property(x => x.Autor)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Isbn)
                .IsRequired()
                .HasColumnType("varchar(17)");

            builder.Property(x => x.DataDePublicacao)
                .IsRequired();

            builder.ToTable("Livros");
        }
    }
}

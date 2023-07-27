using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Royal.Domain.Entities.ProdutoContext;

namespace Royal.Data.Mappings.ProdutoContext
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Descricao)
               .HasMaxLength(300)
               .IsRequired();

            builder.HasMany(c => c.Produtos)
               .WithOne(e => e.Categoria)
               .HasForeignKey(e => e.CategoriaId)
               .IsRequired();
        }
    }
}

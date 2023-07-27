using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Royal.Domain.Entities.ProdutoContext;

namespace Royal.Data.Mappings.ProdutoContext
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Descricao)
               .HasMaxLength(300)
               .IsRequired();

            builder.Property(e => e.ImgUrl)
               .HasMaxLength(150)
               .IsRequired();

            builder.HasOne(e => e.Categoria)
              .WithMany(e => e.Produtos)
              .HasForeignKey(e => e.CategoriaId);
        }
    }
}

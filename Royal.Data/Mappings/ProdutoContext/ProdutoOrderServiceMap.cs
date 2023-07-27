using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Royal.Domain.Entities.ProdutoContext;

namespace Royal.Data.Mappings.ProdutoContext
{
    public class ProdutoOrderServiceMap : IEntityTypeConfiguration<ProdutoOrderService>
    {
        public void Configure(EntityTypeBuilder<ProdutoOrderService> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}

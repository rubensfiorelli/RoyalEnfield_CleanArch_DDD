using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Royal.Domain.Entities.ProdutoContext;

namespace Royal.Data.Mappings.ProdutoContext
{
    public class ProdutoOrderMap : IEntityTypeConfiguration<ProdutoOrder>
    {
        public void Configure(EntityTypeBuilder<ProdutoOrder> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TrackingCode)
                .HasMaxLength(10);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Royal.Domain.Entities.ClienteContext;

namespace Royal.Data.Mappings.ClinteContext
{
    public class MotocicletaMap : IEntityTypeConfiguration<Motocicleta>
    {
        public void Configure(EntityTypeBuilder<Motocicleta> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Modelo)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(entity => entity.Cor)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(entity => entity.Chassis)
               .HasMaxLength(20)
               .IsRequired();



        }
    }
}

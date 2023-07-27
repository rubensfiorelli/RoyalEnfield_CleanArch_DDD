using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Royal.Domain.Entities.ClienteContext;

namespace Royal.Data.Mappings.ClinteContext
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.PrimeiroNome)
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(e => e.UltimoNome)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(e => e.Celular)
               .HasMaxLength(11)
               .IsRequired();

            builder.HasMany(e => e.Motocicletas)
              .WithOne(e => e.Cliente)
              .HasForeignKey(e => e.ClienteId);


        }
    }
}

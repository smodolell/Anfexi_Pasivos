using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class PSV_TipoPagoConfiguration : IEntityTypeConfiguration<PSV_TipoPago>
{
    public void Configure(EntityTypeBuilder<PSV_TipoPago> builder)
    {
        builder.ToTable("PSV_TipoPago", "psv");

        builder.HasKey(e => e.IdTipoPago);

        builder.Property(e => e.TipoPago)
            .IsRequired()
            .HasMaxLength(100);
    }
}

using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class PSV_TipoPagoCapitalConfiguration : IEntityTypeConfiguration<PSV_TipoPagoCapital>
{
    public void Configure(EntityTypeBuilder<PSV_TipoPagoCapital> builder)
    {
        builder.ToTable("PSV_TipoPagoCapital", "psv");

        builder.HasKey(e => e.IdTipoPagoCapital);

        builder.Property(e => e.TipoPagoCapital)
            .IsRequired()
            .HasMaxLength(100);
    }
}

using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class PSV_TipoTablaAmortizaConfiguration : IEntityTypeConfiguration<PSV_TipoTablaAmortiza>
{
    public void Configure(EntityTypeBuilder<PSV_TipoTablaAmortiza> builder)
    {
        builder.ToTable("PSV_TipoTablaAmortiza", "psv");

        builder.HasKey(e => e.IdTipoTablaAmortiza);

        builder.Property(e => e.TipoTablaAmortiza)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.EsCapitalizable)
            .IsRequired();

        builder.Property(e => e.Activo)
            .IsRequired();
    }
}

using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class TipoGeneracionComprobanteConfiguration : IEntityTypeConfiguration<TipoGeneracionComprobante>
{
    public void Configure(EntityTypeBuilder<TipoGeneracionComprobante> builder)
    {
        builder.ToTable("TipoGeneracionComprobante", "cat");

        builder.HasKey(e => e.IdTipoGeneracionComprobante);

        builder.Property(e => e.TipoGeneracionComprobante1)
            .HasColumnName("TipoGeneracionComprobante")
            .IsRequired()
            .HasMaxLength(100);
    }
}

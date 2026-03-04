using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class TasaConfiguration : IEntityTypeConfiguration<Tasa>
{
    public void Configure(EntityTypeBuilder<Tasa> builder)
    {
        builder.ToTable("Tasa", "cat");

        builder.HasKey(e => e.IdTasa);

        builder.Property(e => e.Tasa1)
            .HasColumnName("Tasa")
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(e => e.TipoCredito)
            .WithMany()
            .HasForeignKey(e => e.IdTipoCredito)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

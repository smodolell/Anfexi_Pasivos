using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("Contrato", "sac");

        builder.HasKey(e => e.IdContrato);

        builder.Property(e => e.Contrato1)
            .HasColumnName("Contrato")
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(e => e.EstatusContrato)
            .WithMany(es => es.Contrato)
            .HasForeignKey(e => e.IdEstatusContrato)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SB_Periodicidad)
            .WithMany(p => p.Contrato)
            .HasForeignKey(e => e.IdPeriodicidad)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.SB_TipoMoneda)
            .WithMany(m => m.Contrato)
            .HasForeignKey(e => e.IdMoneda)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Tasa1)
            .WithMany(t => t.Contrato)
            .HasForeignKey(e => e.IdTasa)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TipoCredito)
            .WithMany()
            .HasForeignKey(e => e.IdTipoCredito)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

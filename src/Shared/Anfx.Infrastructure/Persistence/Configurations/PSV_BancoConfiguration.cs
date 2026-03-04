using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class PSV_BancoConfiguration : IEntityTypeConfiguration<PSV_Banco>
{
    public void Configure(EntityTypeBuilder<PSV_Banco> builder)
    {
        builder.ToTable("PSV_Banco", "psv");

        builder.HasKey(e => e.IdBanco);

        builder.Property(e => e.Banco)
            .IsRequired()
            .HasMaxLength(150);
    }
}

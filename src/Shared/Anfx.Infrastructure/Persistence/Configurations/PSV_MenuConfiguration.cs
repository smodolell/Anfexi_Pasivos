using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class PSV_MenuConfiguration : IEntityTypeConfiguration<PSV_Menu>
{
    public void Configure(EntityTypeBuilder<PSV_Menu> builder)
    {
        builder.ToTable("PSV_Menu", "psv");

        builder.HasKey(e => e.ID);

        builder.Property(e => e.Titulo)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Area)
            .HasMaxLength(100);

        builder.Property(e => e.Controller)
            .HasMaxLength(100);

        builder.Property(e => e.Action)
            .HasMaxLength(100);

        builder.Property(e => e.Icon)
            .HasMaxLength(100);
    }
}

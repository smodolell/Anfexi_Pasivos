using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class PSV_ParameterConfiguration : IEntityTypeConfiguration<PSV_Parameter>
{
    public void Configure(EntityTypeBuilder<PSV_Parameter> builder)
    {
        builder.ToTable("PSV_Parameter", "psv");

        builder.HasKey(e => e.ID);

        builder.Property(e => e.Text)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Value)
            .IsRequired();
    }
}

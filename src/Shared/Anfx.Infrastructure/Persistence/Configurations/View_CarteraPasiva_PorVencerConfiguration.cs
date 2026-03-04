using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class View_CarteraPasiva_PorVencerConfiguration : IEntityTypeConfiguration<View_CarteraPasiva_PorVencer>
{
    public void Configure(EntityTypeBuilder<View_CarteraPasiva_PorVencer> builder)
    {
        builder.HasNoKey();
        builder.ToView("View_CarteraPasiva_PorVencer");
    }
}

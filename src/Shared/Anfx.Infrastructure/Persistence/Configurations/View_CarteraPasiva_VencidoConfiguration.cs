using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class View_CarteraPasiva_VencidoConfiguration : IEntityTypeConfiguration<View_CarteraPasiva_Vencido>
{
    public void Configure(EntityTypeBuilder<View_CarteraPasiva_Vencido> builder)
    {
        builder.HasNoKey();
        builder.ToView("View_CarteraPasiva_Vencido");
    }
}

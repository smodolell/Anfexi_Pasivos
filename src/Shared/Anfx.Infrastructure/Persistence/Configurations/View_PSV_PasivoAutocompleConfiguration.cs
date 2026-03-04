using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class View_PSV_PasivoAutocompleConfiguration : IEntityTypeConfiguration<View_PSV_PasivoAutocomple>
{
    public void Configure(EntityTypeBuilder<View_PSV_PasivoAutocomple> builder)
    {
        builder.HasNoKey();
        builder.ToView("View_PSV_PasivoAutocomple");
    }
}

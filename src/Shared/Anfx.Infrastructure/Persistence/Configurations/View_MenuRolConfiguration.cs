using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class View_MenuRolConfiguration : IEntityTypeConfiguration<View_MenuRol>
{
    public void Configure(EntityTypeBuilder<View_MenuRol> builder)
    {
        builder.HasKey(e => new { e.RolID, e.MenuID });
        builder.ToView("View_MenuRol");
    }
}

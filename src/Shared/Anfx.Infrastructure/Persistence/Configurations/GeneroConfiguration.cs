using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anfx.Infrastructure.Persistence.Configurations;

public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable("Genero", "cat");

        builder.HasKey(e => e.IdGenero);

        builder.Property(e => e.Titulo)
            .IsRequired()
            .HasMaxLength(50);
    }
}

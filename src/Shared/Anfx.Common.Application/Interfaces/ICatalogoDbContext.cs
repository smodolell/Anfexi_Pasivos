using Anfx.Domain.Entities;
using Anfx.Profuturo.Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anfx.Common.Application.Interfaces;

public interface ICatalogoDbContext
{
    DbSet<Usuario> Usuarios { get; }
    DbSet<Colonia> Colonias { get; }
    DbSet<Rol> Roles { get; }
    DbSet<Empresa> Empresas { get; }
    DbSet<TipoDireccion> TiposDirecciones { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
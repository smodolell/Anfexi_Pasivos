using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anfx.Common.Application.Interfaces;

public interface ISistemaDbContext
{
    DbSet<Usuario> Usuarios { get; }
    DbSet<Rol> Roles { get; }
    DbSet<Empresa> Empresas { get; }
    DbSet<Menu> Menus { get; }
    DbSet<TipoDireccion> TiposDirecciones { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
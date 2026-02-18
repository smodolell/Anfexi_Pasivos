namespace Anfx.Sistema.Application.Common.Interfaces;

public interface ISistemaDbContext
{
    DbSet<Usuario> Usuarios { get; }
    DbSet<Rol> Roles { get; }
    DbSet<Empresa> Empresas { get; }
    DbSet<Menu> Menus { get; }
    DbSet<TipoDireccion> TiposDirecciones { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
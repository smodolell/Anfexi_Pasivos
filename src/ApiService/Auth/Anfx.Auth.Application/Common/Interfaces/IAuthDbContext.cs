namespace Anfx.Auth.Application.Common.Interfaces;

public interface IAuthDbContext
{
    DbSet<Usuario> Usuarios { get; }
    DbSet<Rol> Roles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
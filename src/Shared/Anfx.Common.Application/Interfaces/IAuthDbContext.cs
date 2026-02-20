using Anfx.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anfx.Common.Application.Interfaces;

public interface IAuthDbContext
{
    DbSet<Usuario> Usuarios { get; }
    DbSet<Rol> Roles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
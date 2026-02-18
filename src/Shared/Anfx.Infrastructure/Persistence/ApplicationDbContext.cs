using Anfx.Auth.Application.Common.Interfaces;
using Anfx.Domain.Entities;
using Anfx.Sistema.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Anfx.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext , ISistemaDbContext, IAuthDbContext
{

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Rol> Roles => Set<Rol>();
    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<TipoDireccion> TiposDirecciones => Set<TipoDireccion>();

    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }

 

}

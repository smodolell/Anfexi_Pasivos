using Anfx.Common.Application.Interfaces;
using Anfx.Domain.Entities;
using Anfx.Profuturo.Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anfx.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext , ISistemaDbContext, IAuthDbContext, ICatalogoDbContext
{

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Rol> Roles => Set<Rol>();
    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<TipoDireccion> TiposDirecciones => Set<TipoDireccion>();

    public DbSet<Colonia> Colonias =>  Set<Colonia>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }

 

}

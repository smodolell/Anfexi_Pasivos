using Anfx.Sistema.Application.Features.Menus.DTOs;

namespace Anfx.Sistema.Application.Features.Menus.Commands;

public record UpdateMenuCommand(int Id, UpdateMenuDto Menu) : ICommand<Result<MenuDto>>;

public class UpdateMenuCommandHandler : ICommandHandler<UpdateMenuCommand, Result<MenuDto>>
{
    private readonly ISistemaDbContext _context;
    private readonly IMapper _mapper;

    public UpdateMenuCommandHandler(ISistemaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<MenuDto>> HandleAsync(UpdateMenuCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (menu == null)
            {
                return Result.NotFound("Menú no encontrado");
            }

            // El menú padre no se puede cambiar en la actualización

            // Actualizar propiedades
            menu.sMenu = request.Menu.sMenu;
            menu.Area = request.Menu.Area;
            menu.Controlador = request.Menu.Controlador;
            menu.Accion = request.Menu.Accion;
            menu.Icono = request.Menu.Icono;
            // MenuId_Padre se mantiene igual ya que no está en UpdateMenuDto

            await _context.SaveChangesAsync(cancellationToken);

            var menuDto = _mapper.Map<MenuDto>(menu);
            return Result.Success(menuDto, "Menú actualizado exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Error($"Error al actualizar el menú: {ex.Message}");
        }
    }
}

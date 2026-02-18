using Anfx.Sistema.Application.Features.Menus.DTOs;


namespace Anfx.Sistema.Application.Features.Menus.Commands;

public record CreateMenuCommand(CreateMenuDto Menu) : ICommand<Result<MenuDto>>;

public class CreateMenuCommandHandler : ICommandHandler<CreateMenuCommand, Result<MenuDto>>
{
    private readonly ISistemaDbContext _context;
    private readonly IMapper _mapper;

    public CreateMenuCommandHandler(ISistemaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<MenuDto>> HandleAsync(CreateMenuCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            // Verificar si el menú padre existe (si se especifica)
            if (request.Menu.MenuId_Padre.HasValue)
            {
                var menuPadre = await _context.Menus
                    .FirstOrDefaultAsync(m => m.Id == request.Menu.MenuId_Padre && m.Activo, cancellationToken);

                if (menuPadre == null)
                {
                    return Result.NotFound("El menú padre no existe");
                }
            }

            var menu = _mapper.Map<Menu>(request.Menu);

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(cancellationToken);

            var menuDto = _mapper.Map<MenuDto>(menu);
            return Result.Success(menuDto, "Menú creado exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Error($"Error al crear el menú: {ex.Message}");
        }
    }
}

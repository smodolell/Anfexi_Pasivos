using Anfx.Sistema.Application.Features.Menus.DTOs;
using Azure.Core;

namespace Anfx.Sistema.Application.Features.Menus.Queries;

public record GetMenuByIdQuery(int Id) : IQuery<Result<MenuDto>>;

public class GetMenuByIdQueryHandler : IQueryHandler<GetMenuByIdQuery, Result<MenuDto>>
{
    private readonly ISistemaDbContext _context;
    private readonly IMapper _mapper;

    public GetMenuByIdQueryHandler(ISistemaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<MenuDto>> HandleAsync(GetMenuByIdQuery request, CancellationToken cancellationToken = default)
    {
        try
        {
            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == request.Id && m.Activo, cancellationToken);

            if (menu == null)
            {
                return Result.NotFound("Menú no encontrado");
            }

            var menuDto = _mapper.Map<MenuDto>(menu);
            return Result.Success(menuDto);
        }
        catch (Exception ex)
        {
            return Result.Error($"Error al obtener el menú: {ex.Message}");
        }
    }
}

using Anfx.Sistema.Application.Features.Menus.DTOs;

namespace Anfx.Sistema.Application.Features.Menus.Queries;

public record GetAllMenusQuery : IQuery<Result<List<MenuDto>>>;

public class GetAllMenusQueryHandler : IQueryHandler<GetAllMenusQuery, Result<List<MenuDto>>>
{
    private readonly ISistemaDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMenusQueryHandler(ISistemaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<List<MenuDto>>> HandleAsync(GetAllMenusQuery message, CancellationToken cancellationToken = default)
    {
        try
        {
            var menus = await _context.Menus
                .Where(m => m.Activo)
                .OrderBy(m => m.sMenu)
                .ToListAsync(cancellationToken);

            var menusDto = _mapper.Map<List<MenuDto>>(menus);
            return Result.Success(menusDto);
        }
        catch (Exception ex)
        {
            return Result.Error($"Error al obtener los menús: {ex.Message}");
        }
    }
}

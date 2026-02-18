using Anfx.Sistema.Application.Features.Menus.DTOs;

namespace Anfx.Sistema.Application.Features.Menus.Queries;

public record GetMenusQuery(int Page, int Size, string? SearchTerm, int? IdPadre) : IQuery<Result<PagedResultDto<MenuDto>>>;

public class GetMenusQueryHandler : IQueryHandler<GetMenusQuery, Result<PagedResultDto<MenuDto>>>
{
    private readonly ISistemaDbContext _context;
    private readonly IMapper _mapper;

    public GetMenusQueryHandler(ISistemaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<Result<PagedResultDto<MenuDto>>> HandleAsync(GetMenusQuery request, CancellationToken cancellationToken = default)
    {
        try
        {
            var query = _context.Menus.Where(m => m.Activo);

            if (request.IdPadre.HasValue)
            {
                query = query.Where(m => m.MenuId_Padre == request.IdPadre);
            }

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(m => m.sMenu.Contains(request.SearchTerm) ||
                                       m.Area.Contains(request.SearchTerm));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var menus = await query
                .OrderBy(m => m.sMenu)
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .ToListAsync(cancellationToken);

            var menusDto = _mapper.Map<IEnumerable<MenuDto>>(menus);

            var pagedResult = new PagedResultDto<MenuDto>
            {
                Results = menusDto,
                CurrentPage = request.Page,
                PageSize = request.Size,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / request.Size)
            };

            return Result.Success(pagedResult);
        }
        catch (Exception ex)
        {
            return Result.Error($"Error al obtener los menús: {ex.Message}");
        }
    }
}

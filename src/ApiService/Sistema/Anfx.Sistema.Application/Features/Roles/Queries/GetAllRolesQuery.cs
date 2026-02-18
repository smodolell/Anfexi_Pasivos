using Anfx.Sistema.Application.Features.Roles.DTOs;

namespace Anfx.Sistema.Application.Features.Roles.Queries;

public record GetAllRolesQuery : IQuery<Result<IEnumerable<RolDto>>>;

public class GetAllRolesQueryHandler : IQueryHandler<GetAllRolesQuery, Result<IEnumerable<RolDto>>>
{
    private readonly ISistemaDbContext _context;
    private readonly IMapper _mapper;

    public GetAllRolesQueryHandler(ISistemaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<RolDto>>> HandleAsync(GetAllRolesQuery message, CancellationToken cancellationToken = default)
    {
        try
        {
            var roles = await _context.Roles
                .Where(r => r.Activo)
                .OrderBy(r => r.sRol)
                .ToListAsync(cancellationToken);

            var rolesDto = _mapper.Map<IEnumerable<RolDto>>(roles);
            return Result.Success(rolesDto);
        }
        catch (Exception ex)
        {
            return Result.Error($"Error al obtener los roles: {ex.Message}");
        }
    }

   
}

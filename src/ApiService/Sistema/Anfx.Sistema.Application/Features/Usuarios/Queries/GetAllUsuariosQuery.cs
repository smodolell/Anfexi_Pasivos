using Anfx.Sistema.Application.Features.Usuarios.DTOs;

namespace Anfx.Sistema.Application.Features.Usuarios.Queries;

public class GetAllUsuariosQuery : IQuery<Result<List<UsuarioDto>>>
{
}

public class GetAllUsuariosQueryHandler : IQueryHandler<GetAllUsuariosQuery, Result<List<UsuarioDto>>>
{
    private readonly ISistemaDbContext _context;
    private readonly IMapper _mapper;

    public GetAllUsuariosQueryHandler(ISistemaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<List<UsuarioDto>>> HandleAsync(GetAllUsuariosQuery message, CancellationToken cancellationToken = default)
    {
        try
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Rol)
                .OrderBy(u => u.NombreCompleto)
                .ToListAsync(cancellationToken);

            var usuariosDto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return Result.Success(usuariosDto);
        }
        catch (Exception ex)
        {
            return Result.Error($"Error interno del servidor {ex.Message}");
        }
    }
}

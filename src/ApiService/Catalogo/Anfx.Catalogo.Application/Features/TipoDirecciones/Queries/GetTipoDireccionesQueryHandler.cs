using Anfx.Catalogo.Application.Features.TipoDirecciones.DTOs;

namespace Anfx.Catalogo.Application.Features.TipoDirecciones.Queries;

public class GetTipoDireccionesQueryHandler : IQueryHandler<GetTipoDireccionesQuery, Result<IEnumerable<TipoDireccionDto>>>
{
    private readonly ICatalogoDbContext _context;
    private readonly IMapper _mapper;

    public GetTipoDireccionesQueryHandler(ICatalogoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    

    public async Task<Result<IEnumerable<TipoDireccionDto>>> HandleAsync(GetTipoDireccionesQuery message, CancellationToken cancellationToken = default)
    {
        var tipoDirecciones = await _context.TiposDirecciones
            .ToListAsync(cancellationToken);

        var result = _mapper.Map<IEnumerable<TipoDireccionDto>>(tipoDirecciones);

        return Result.Success(result);
    }
}

using Anfx.Pasivos.Application.Features.Catalogos.DTOs;

namespace Anfx.Pasivos.Application.Features.Catalogos.Queries;

internal class GetTipoCreditoByIdQueryHandler:IQueryHandler<GetTipoCreditoByIdQuery, Result<TipoCreditoDto>>
{
    private readonly IPasivoDbContext _context;
    private readonly IMapper _mapper;
    public GetTipoCreditoByIdQueryHandler(IPasivoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Result<TipoCreditoDto>> HandleAsync(GetTipoCreditoByIdQuery request, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _context.PSV_TipoCredito.SingleOrDefaultAsync(r => r.IdTipoCredito == request.Id, cancellationToken);
            if (entity == null)
            {
                return Result.NotFound("Tipo de Credito no existe");
            }
            var dto = _mapper.Map<TipoCreditoDto>(entity);
            return Result.Success(dto);
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}

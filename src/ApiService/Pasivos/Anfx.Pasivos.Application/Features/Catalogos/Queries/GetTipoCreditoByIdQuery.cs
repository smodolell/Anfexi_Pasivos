using Anfx.Pasivos.Application.Features.Catalogos.DTOs;

namespace Anfx.Pasivos.Application.Features.Catalogos.Queries;

public class GetTipoCreditoByIdQuery : IQuery<Result<TipoCreditoDto>>
{
    public int Id { get; set; }
}

using Anfx.Catalogo.Application.Features.TipoDirecciones.DTOs;

namespace Anfx.Catalogo.Application.Features.TipoDirecciones.Queries;

public record GetTipoDireccionesQuery : IQuery<Result<IEnumerable<TipoDireccionDto>>>
{
}

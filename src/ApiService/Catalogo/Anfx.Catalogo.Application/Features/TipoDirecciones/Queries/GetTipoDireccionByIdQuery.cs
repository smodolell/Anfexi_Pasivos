using Anfx.Catalogo.Application.Features.TipoDirecciones.DTOs;

namespace Anfx.Catalogo.Application.Features.TipoDirecciones.Queries;

public record GetTipoDireccionByIdQuery : IQuery<Result<TipoDireccionDto>>
{
    public int Id { get; init; }
}

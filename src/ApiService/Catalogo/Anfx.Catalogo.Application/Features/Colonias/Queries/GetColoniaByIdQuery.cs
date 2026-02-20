using Anfx.Catalogo.Application.Features.Colonias.DTOs;

namespace Anfx.Catalogo.Application.Features.Colonias.Queries;

public record GetColoniaByIdQuery : IQuery<Result<ColoniaDto>>
{
    public int Id { get; init; }
}

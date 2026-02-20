using Anfx.Catalogo.Application.Features.Colonias.DTOs;

namespace Anfx.Catalogo.Application.Features.Colonias.Queries;

public record GetColoniasByIdQuery : IQuery<Result<ColoniaComponentDto>>
{
    public int Id { get; init; }
}

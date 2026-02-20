using Anfx.Catalogo.Application.Features.Colonias.DTOs;

namespace Anfx.Catalogo.Application.Features.Colonias.Queries;

public record GetColoniasForExportQuery : IQuery<Result<IEnumerable<ColoniaDto>>>
{
    public string? SearchTerm { get; init; }
}

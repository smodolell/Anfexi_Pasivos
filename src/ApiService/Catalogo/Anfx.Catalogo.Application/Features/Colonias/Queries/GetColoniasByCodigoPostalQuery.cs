using Anfx.Catalogo.Application.Features.Colonias.DTOs;

namespace Anfx.Catalogo.Application.Features.Colonias.Queries;

public record GetColoniasByCodigoPostalQuery : IQuery<Result<ColoniaComponentDto>>
{
    public string CodigoPostal { get; init; } = string.Empty;
}

using Anfx.Catalogo.Application.Features.Colonias.DTOs;

namespace Anfx.Catalogo.Application.Features.Colonias.Queries;

public record GetColoniasQuery : IQuery<Result<IEnumerable<ColoniaDto>>>;

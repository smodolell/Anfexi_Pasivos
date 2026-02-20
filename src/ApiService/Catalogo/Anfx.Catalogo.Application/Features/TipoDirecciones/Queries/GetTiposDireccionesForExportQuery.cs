using Anfx.Catalogo.Application.Features.TipoDirecciones.DTOs;

namespace Anfx.Catalogo.Application.Features.TipoDirecciones.Queries;

public class GetTiposDireccionesForExportQuery : IQuery<IEnumerable<TipoDireccionDto>>
{
    public string? SearchTerm { get; set; }
}
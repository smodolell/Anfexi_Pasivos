
using Anfx.Catalogo.Application.Features.TipoDirecciones.DTOs;

namespace Anfx.Catalogo.Application.Features.TipoDirecciones.Commands;

public record CreateTipoDireccionCommand : ICommand<Result<TipoDireccionDto>>
{
    public string sTipoDireccion { get; init; } = string.Empty;
}


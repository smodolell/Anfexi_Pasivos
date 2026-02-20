namespace Anfx.Catalogo.Application.Features.TipoDirecciones.Commands;

public record DeleteTipoDireccionCommand : ICommand<Result>
{
    public int Id { get; init; }
}

namespace Anfx.Catalogo.Application.Features.Colonias.Commands;

public record DeleteColoniaCommand : ICommand<Result>
{
    public int Id { get; init; }
}

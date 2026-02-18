namespace Anfx.Sistema.Application.Features.Menus.Commands;

public record DeleteMenuCommand(int Id) : ICommand<Result<bool>>;

public class DeleteMenuCommandHandler : ICommandHandler<DeleteMenuCommand, Result<bool>>
{
    private readonly ISistemaDbContext _context;

    public DeleteMenuCommandHandler(ISistemaDbContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> HandleAsync(DeleteMenuCommand message, CancellationToken cancellationToken = default)
    {
        try
        {
            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == message.Id, cancellationToken);

            if (menu == null)
            {
                return Result.Error("Menú no encontrado");
            }


            // Soft delete
            menu.Activo = false;

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success(true, "Menú eliminado exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Error($"Error al eliminar el menú: {ex.Message}");
        }
    }
}

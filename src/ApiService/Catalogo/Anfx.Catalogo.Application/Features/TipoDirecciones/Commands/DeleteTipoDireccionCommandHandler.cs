namespace Anfx.Catalogo.Application.Features.TipoDirecciones.Commands;

public class DeleteTipoDireccionCommandHandler : ICommandHandler<DeleteTipoDireccionCommand, Result>
{
    private readonly ICatalogoDbContext _context;

    public DeleteTipoDireccionCommandHandler(ICatalogoDbContext context)
    {
        _context = context;
    }


    public async Task<Result> HandleAsync(DeleteTipoDireccionCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var tipoDireccion = await _context.TiposDirecciones.SingleOrDefaultAsync(r => r.Id == request.Id);
            if (tipoDireccion == null)
            {
                return Result.NotFound("Tipo de dirección no encontrado");
            }
            _context.TiposDirecciones.Remove(tipoDireccion);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.SuccessWithMessage("Tipo de dirección eliminado exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);

        }
    }
}

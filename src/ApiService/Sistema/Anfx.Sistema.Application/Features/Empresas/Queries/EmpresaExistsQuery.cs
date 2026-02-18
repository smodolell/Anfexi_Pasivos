namespace Anfx.Sistema.Application.Features.Empresas.Queries
{
    public record EmpresaExistsQuery(int Id) : IQuery<Result<bool>>;

    public class EmpresaExistsQueryHandler : IQueryHandler<EmpresaExistsQuery, Result<bool>>
    {
        private readonly ISistemaDbContext _context;

        public EmpresaExistsQueryHandler(ISistemaDbContext context)
        {
            _context = context;
        }

        
        public async Task<Result<bool>> HandleAsync(EmpresaExistsQuery message, CancellationToken cancellationToken = default)
        {
            try
            {
                var exists = await _context.Empresas
                    .AnyAsync(e => e.Id == message.Id, cancellationToken);

                return Result.Success(exists);
            }
            catch (Exception ex)
            {
                return Result.Error($"Error al verificar la existencia de la empresa: {ex.Message}");
            }
        }
    }
}

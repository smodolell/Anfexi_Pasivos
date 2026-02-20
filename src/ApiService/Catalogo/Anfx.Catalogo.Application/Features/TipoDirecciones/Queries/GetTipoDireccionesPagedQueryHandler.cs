using Anfx.Catalogo.Application.Features.TipoDirecciones.DTOs;

namespace Anfx.Catalogo.Application.Features.TipoDirecciones.Queries;

public class GetTipoDireccionesPagedQueryHandler : IQueryHandler<GetTipoDireccionesPagedQuery, Result<PagedResultDto<TipoDireccionDto>>>
{
    private readonly ICatalogoDbContext _context;
    private readonly IPaginator _paginator;
    private readonly IValidator<GetTipoDireccionesPagedQuery> _validator;

    public GetTipoDireccionesPagedQueryHandler(ICatalogoDbContext context, IPaginator paginator, IValidator<GetTipoDireccionesPagedQuery> validator)
    {
        _context = context;
        _paginator = paginator;
        _validator = validator;
    }

    public async Task<Result<PagedResultDto<TipoDireccionDto>>> HandleAsync(GetTipoDireccionesPagedQuery request, CancellationToken cancellationToken = default)
    {

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Invalid(validationResult.AsErrors());
        }

        try
        {
            var query = _context.TiposDirecciones.AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(td => td.sTipoDireccion.Contains(request.SearchTerm));
            }

            var result = await _paginator.PaginateAsync<TipoDireccion, TipoDireccionDto>(query, request.Page, request.Size);

            return Result.Success(result, "Tipos de dirección obtenidos exitosamente");
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }

    }
}

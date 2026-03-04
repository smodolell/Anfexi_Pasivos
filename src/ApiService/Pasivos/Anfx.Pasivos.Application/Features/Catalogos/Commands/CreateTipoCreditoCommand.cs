using Anfx.Pasivos.Application.Features.Catalogos.DTOs;

namespace Anfx.Pasivos.Application.Features.Catalogos.Commands;

public class CreateTipoCreditoCommand : ICommand<Result<int>>
{
    public required TipoCreditoDto Model { get; set; }
}


internal class CreateTipoCreditoCommandHandler : ICommandHandler<CreateTipoCreditoCommand, Result<int>>
{
    private readonly IPasivoDbContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<TipoCreditoDto> _validator;

    public CreateTipoCreditoCommandHandler(IPasivoDbContext context, IMapper mapper, IValidator<TipoCreditoDto> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<int>> HandleAsync(CreateTipoCreditoCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var model = request.Model;

            var validationResult = await _validator.ValidateAsync(model, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result.Invalid(validationResult.AsErrors());
            }

            var entity = _mapper.Map<PSV_TipoCredito>(model);
            _context.PSV_TipoCredito.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);


            return Result.Created(entity.IdTipoCredito);

        }
        catch (Exception ex)
        {

            return Result.Error(ex.Message);
        }
    }
}

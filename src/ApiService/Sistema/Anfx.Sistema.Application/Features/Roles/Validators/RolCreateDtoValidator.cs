using Anfx.Sistema.Application.Features.Roles.DTOs;

namespace Anfx.Sistema.Application.Features.Roles.Validators;

public class RolCreateDtoValidator : AbstractValidator<RolCreateDto>
{
    private readonly ISistemaDbContext _context;

    public RolCreateDtoValidator(ISistemaDbContext context)
    {
        _context = context;

        RuleFor(x => x.sRol)
            .NotEmpty().WithMessage("El nombre del rol es requerido")
            .MaximumLength(50).WithMessage("El nombre no puede exceder 50 caracteres")
            .MustAsync(async (nombre, cancellationToken) =>
                !await _context.Roles
                    .AnyAsync(r => r.sRol == nombre, cancellationToken))
            .WithMessage("El nombre del rol ya está registrado"); ;

        RuleFor(x => x.Descripcion)
            .MaximumLength(200).WithMessage("La descripción no puede exceder 200 caracteres");
        
    }
}
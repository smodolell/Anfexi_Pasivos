

namespace Anfx.Pasivos.Application.Services.DTOs;


public class BancoSpec : Specification<PSV_Banco>
{

    public BancoSpec(string? searchTerm)
    {
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            Query.Where(w => w.Banco.Contains(searchTerm));
        }
    }


}
public class BancoListItemDto
{
    public int Id { get; set; }
    public string Banco { get; set; } = string.Empty;
}

public class CreateBancoDto
{
    public string Banco { get; set; }
}
public class BancoDto
{
    public int Id { get; set; }
    public string Banco { get; set; }
}

public class BancoDtoValidator : AbstractValidator<BancoDto>
{
    public BancoDtoValidator()
    {
        RuleFor(r => r.Banco)
            .NotEmpty().WithMessage("Requerido")
            .MaximumLength(150).WithMessage("debe ser < que 150 Car.");
    }
}
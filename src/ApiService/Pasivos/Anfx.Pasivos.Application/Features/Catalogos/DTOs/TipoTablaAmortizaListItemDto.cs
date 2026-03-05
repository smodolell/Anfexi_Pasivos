namespace Anfx.Pasivos.Application.Features.Catalogos.DTOs;

public class TipoTablaAmortizaListItemDto
{
    public int Id { get; set; }
    public string TipoTablaAmortiza { get; set; } = string.Empty;
    public bool Activo { get; set; }
}

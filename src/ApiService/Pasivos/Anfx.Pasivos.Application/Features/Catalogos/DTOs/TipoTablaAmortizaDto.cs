using System.ComponentModel.DataAnnotations;

namespace Anfx.Pasivos.Application.Features.Catalogos.DTOs;

public class TipoTablaAmortizaDto
{
    [StringLength(150, ErrorMessage = "debe ser < que 150 Car.")]
    [Required(ErrorMessage = "Requerido")]
    public string TipoTablaAmortiza { get; set; } = string.Empty;
    public bool EsCapitalizable { get; set; }
    public bool Activo { get; set; }
}

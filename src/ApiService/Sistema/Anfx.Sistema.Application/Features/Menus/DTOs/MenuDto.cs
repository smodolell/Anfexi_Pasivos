using System.ComponentModel.DataAnnotations;

namespace Anfx.Sistema.Application.Features.Menus.DTOs
{
    public class MenuDto
    {
        public int Id { get; set; }
        public int? MenuId_Padre { get; set; }
        public string sMenu { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Controlador { get; set; } = string.Empty;
        public string Accion { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public string? NombreMenuPadre { get; set; }
    }

    public class CreateMenuDto
    {
        [Required(ErrorMessage = "El título es requerido")]
        [MaxLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
        public string sMenu { get; set; } = string.Empty;

        [Required(ErrorMessage = "El área es requerida")]
        [MaxLength(100, ErrorMessage = "El área no puede exceder 100 caracteres")]
        public string Area { get; set; } = string.Empty;

        [Required(ErrorMessage = "El controlador es requerido")]
        [MaxLength(100, ErrorMessage = "El controlador no puede exceder 100 caracteres")]
        public string Controlador { get; set; } = string.Empty;

        [Required(ErrorMessage = "La acción es requerida")]
        [MaxLength(100, ErrorMessage = "La acción no puede exceder 100 caracteres")]
        public string Accion { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "El icono no puede exceder 100 caracteres")]
        public string Icono { get; set; } = string.Empty;

        public int? MenuId_Padre { get; set; }
    }

    public class UpdateMenuDto
    {
        [Required(ErrorMessage = "El título es requerido")]
        [MaxLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
        public string sMenu { get; set; } = string.Empty;

        [Required(ErrorMessage = "El área es requerida")]
        [MaxLength(100, ErrorMessage = "El área no puede exceder 100 caracteres")]
        public string Area { get; set; } = string.Empty;

        [Required(ErrorMessage = "El controlador es requerido")]
        [MaxLength(100, ErrorMessage = "El controlador no puede exceder 100 caracteres")]
        public string Controlador { get; set; } = string.Empty;

        [Required(ErrorMessage = "La acción es requerida")]
        [MaxLength(100, ErrorMessage = "La acción no puede exceder 100 caracteres")]
        public string Accion { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "El icono no puede exceder 100 caracteres")]
        public string Icono { get; set; } = string.Empty;

        public bool Activo { get; set; }
    }

    public class MenuJerarquicoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Controlador { get; set; } = string.Empty;
        public string Accion { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public List<MenuDto> SubMenus { get; set; } = new List<MenuDto>();
    }
}

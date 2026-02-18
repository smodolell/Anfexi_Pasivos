using Anfx.Auth.Application.Feactures.Auth.DTOs;

namespace Anfx.Auth.Application.Feactures.Auth.Commands.Login;

public record LoginCommand : ICommand<Result<UsuarioLoginDto>>
{
    public string Email { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Contrasenia { get; set; } = string.Empty;
}

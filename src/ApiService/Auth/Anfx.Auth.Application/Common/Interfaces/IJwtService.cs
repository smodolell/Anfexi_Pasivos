using Anfx.Auth.Application.Feactures.Auth.DTOs;

namespace Anfx.Auth.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(UsuarioLoginDto user);
        string GenerateRefreshToken();
        bool ValidateToken(string token);
        UsuarioLoginDto? GetUserFromToken(string token);
    }
}

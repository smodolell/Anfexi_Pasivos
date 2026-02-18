using Anfx.Sistema.Application.Features.Roles.DTOs;

namespace Anfx.Sistema.Application.Features.Roles.Commands;

public record UpdateRolCommand(int Id, RolUpdateDto Model) : ICommand<Result<RolDto>>;

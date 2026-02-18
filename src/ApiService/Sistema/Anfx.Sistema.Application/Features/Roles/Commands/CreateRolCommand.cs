using Anfx.Sistema.Application.Features.Roles.DTOs;

namespace Anfx.Sistema.Application.Features.Roles.Commands;

public record CreateRolCommand(RolCreateDto Model) : ICommand<Result<RolDto>>;

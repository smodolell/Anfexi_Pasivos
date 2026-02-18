using Anfx.Sistema.ApiService.Infrastructure;
using Anfx.Sistema.Application.Common.DTOs;
using Anfx.Sistema.Application.Features.Menus.Commands;
using Anfx.Sistema.Application.Features.Menus.DTOs;
using Anfx.Sistema.Application.Features.Menus.Queries;
using Ardalis.Result;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace Anfx.Sistema.ApiService.Endpoints;

public class Menus : EndpointGroupBase
{
    public override string? GroupName => "menus";

    public override void Map(RouteGroupBuilder groupBuilder)
    {
        var group = groupBuilder.MapGroup("/")
            .WithTags("Menus");

        // GET /api/menus - Paginados
        group.MapGet("/", GetPaginated)
            .WithName("GetMenusPaginados")
            .WithSummary("Obtiene menús paginados y filtrados")
            .WithDescription("Obtiene un listado paginado de menús con filtros opcionales")
            .Produces<PagedResultDto<MenuDto>>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

        // GET /api/menus/all - Todos los menús
        group.MapGet("/all", GetAll)
            .WithName("GetAllMenus")
            .WithSummary("Obtiene todos los menús")
            .WithDescription("Obtiene un listado completo de todos los menús")
            .Produces<IEnumerable<MenuDto>>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

        // GET /api/menus/{id} - Por ID
        group.MapGet("/{id}", GetById)
            .WithName("GetMenuById")
            .WithSummary("Obtiene un menú por ID")
            .WithDescription("Obtiene los detalles de un menú específico por su ID")
            .Produces<MenuDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

        // POST /api/menus - Crear
        group.MapPost("/", Create)
            .WithName("CreateMenu")
            .WithSummary("Crea un nuevo menú")
            .WithDescription("Crea un nuevo menú en el sistema")
            .Accepts<CreateMenuDto>("application/json")
            .Produces<MenuDto>(StatusCodes.Status201Created)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

        // PUT /api/menus/{id} - Actualizar
        group.MapPut("/{id}", Update)
            .WithName("UpdateMenu")
            .WithSummary("Actualiza un menú existente")
            .WithDescription("Actualiza los datos de un menú existente")
            .Accepts<UpdateMenuDto>("application/json")
            .Produces<MenuDto>(StatusCodes.Status200OK)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

        // DELETE /api/menus/{id} - Eliminar (soft delete)
        group.MapDelete("/{id}", Delete)
            .WithName("DeleteMenu")
            .WithSummary("Elimina un menú")
            .WithDescription("Elimina lógicamente un menú (soft delete)")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
    }

    #region Handlers

    /// <summary>
    /// Obtiene menús paginados y filtrados
    /// </summary>
    public async Task<IResult> GetPaginated(
        [FromServices] IQueryMediator queryMediator,
        [FromQuery] string? q = null,
        [FromQuery] int page = 1,
        [FromQuery] int size = 10,
        [FromQuery] int? idp = null)
    {
        // Validación de parámetros de paginación
        if (page < 1 || size < 1)
        {
            var validationError = Result<PagedResultDto<MenuDto>>.Invalid(new List<ValidationError>
            {
                new() {
                    Identifier = "pagination",
                    ErrorMessage = "Los parámetros de paginación deben ser mayores a 0"
                }
            });
            return validationError.ToCustomMinimalApiResult();
        }

        var query = new GetMenusQuery(page, size, q, idp);
        var result = await queryMediator.QueryAsync(query);
        return result.ToCustomMinimalApiResult();
    }

    /// <summary>
    /// Obtiene todos los menús
    /// </summary>
    public async Task<IResult> GetAll(
        [FromServices] IQueryMediator queryMediator)
    {
        var query = new GetAllMenusQuery();
        var result = await queryMediator.QueryAsync(query);
        return result.ToCustomMinimalApiResult();
    }

    /// <summary>
    /// Obtiene un menú por ID
    /// </summary>
    public async Task<IResult> GetById(
        [FromServices] IQueryMediator queryMediator,
        int id)
    {
        var query = new GetMenuByIdQuery(id);
        var result = await queryMediator.QueryAsync(query);
        return result.ToCustomMinimalApiResult();
    }

    /// <summary>
    /// Crea un nuevo menú
    /// </summary>
    public async Task<IResult> Create(
        [FromServices] ICommandMediator commandMediator,
        [FromBody] CreateMenuDto model)
    {
        // Validación manual (aunque lo ideal es usar FluentValidation con pipeline behavior)
        if (model == null)
        {
            var validationError = Result<MenuDto>.Invalid(new List<ValidationError>
            {
                new() {
                    Identifier = "model",
                    ErrorMessage = "El modelo no puede ser nulo"
                }
            });
            return validationError.ToCustomMinimalApiResult();
        }

        var command = new CreateMenuCommand(model);
        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }

    /// <summary>
    /// Actualiza un menú existente
    /// </summary>
    public async Task<IResult> Update(
        [FromServices] ICommandMediator commandMediator,
        int id,
        [FromBody] UpdateMenuDto model)
    {
        // Validación de consistencia
        if (model == null)
        {
            var validationError = Result<MenuDto>.Invalid(new List<ValidationError>
            {
                new() {
                    Identifier = "model",
                    ErrorMessage = "El modelo no puede ser nulo"
                }
            });
            return validationError.ToCustomMinimalApiResult();
        }

        var command = new UpdateMenuCommand(id, model);
        var result = await commandMediator.SendAsync(command);

        return result.ToCustomMinimalApiResult();
    }

    /// <summary>
    /// Elimina un menú (soft delete)
    /// </summary>
    public async Task<IResult> Delete(
        [FromServices] ICommandMediator commandMediator,
        int id)
    {
        var command = new DeleteMenuCommand(id);
        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }

    #endregion
}
using Anfx.Common.Application.DTOs;
using Anfx.Pasivos.ApiService.Infrastructure;
using Anfx.Pasivos.ApiService.Responces;
using Anfx.Pasivos.Application.Features.Catalogos.Commands;
using Anfx.Pasivos.Application.Features.Catalogos.DTOs;
using Anfx.Pasivos.Application.Features.Catalogos.Queries;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace Anfx.Pasivos.ApiService.Endpoints;

public class CuentasBancarias : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        var group = groupBuilder.MapGroup("/")
           .WithTags("CuentasBancarias");

        // GET by id
        group.MapGet("/{id}", GetById)
            .WithName("GetCuentaBancariaById")
            .WithSummary("Obtiene una cuenta bancaria por ID")
            .Produces<ApiResponseDto<CuentaBancariaDto>>(StatusCodes.Status200OK)
            .Produces<ApiResponseDto>(StatusCodes.Status404NotFound)
            .Produces<ApiResponseDto>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto>(StatusCodes.Status500InternalServerError);

        group.MapGet("/", GetPaginated)
            .WithSummary("Obtiene cuentas bancarias paginadas y filtradas")
            .Produces<ApiResponseDto<PagedResultDto<CuentaBancariaListItemDto>>>(StatusCodes.Status200OK)
            .Produces<ApiResponseDto>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto>(StatusCodes.Status500InternalServerError);

        group.MapPost("/", Create)
            .WithName("CreateCuentaBancaria")
            .WithSummary("Crea una nueva cuenta bancaria")
            .Accepts<CuentaBancariaDto>("application/json")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status500InternalServerError);

        group.MapPut("/{id}", Update)
            .WithName("UpdateCuentaBancaria")
            .WithSummary("Actualiza una cuenta bancaria")
            .Accepts<CuentaBancariaDto>("application/json")
            .Produces(StatusCodes.Status200OK)
            .Produces<ApiResponseDto>(StatusCodes.Status404NotFound)
            .Produces<ApiResponseDto>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponseDto>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto>(StatusCodes.Status500InternalServerError);
    }

    public async Task<IResult> GetById(
     [FromServices] IQueryMediator queryMediator,
     int id)
    {
        var result = await queryMediator.QueryAsync(new GetCuentaBancariaByIdQuery { Id = id });
        return result.ToCustomMinimalApiResult();
    }

    public async Task<IResult> GetPaginated(
    IQueryMediator queryMediator,
    [FromQuery] string? q = null,
    [FromQuery] int page = 1,
    [FromQuery] int size = 10,
    [FromQuery] string sortColumn = nameof(CuentaBancariaListItemDto.Id),
    [FromQuery] bool sortDescending = false)
    {
        var query = new GetCuentasBancariasQuery
        {
            SearchText = q,
            PageSize = size,
            Page = page,
            SortColumn = sortColumn,
            SortDescending = sortDescending
        };
        var result = await queryMediator.QueryAsync(query);
        return result.ToCustomMinimalApiResult();
    }

    public async Task<IResult> Create(
    [FromServices] ICommandMediator commandMediator,
    [FromBody] CuentaBancariaDto model)
    {
        var command = new CreateCuentaBancariaCommand
        {
            Model = model
        };

        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }

    public async Task<IResult> Update(
    [FromServices] ICommandMediator commandMediator,
    int id,
    [FromBody] CuentaBancariaDto model)
    {
        var command = new UpdateCuentaBancariaCommand
        {
            Id = id,
            Model = model
        };

        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }
}

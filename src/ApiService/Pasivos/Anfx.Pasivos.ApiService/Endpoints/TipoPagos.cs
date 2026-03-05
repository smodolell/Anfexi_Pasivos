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

public class TipoPagos : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        var group = groupBuilder.MapGroup("/")
           .WithTags("TipoPagos");

        // GET by id
        group.MapGet("/{id}", GetById)
            .WithName("GetTipoPagoById")
            .WithSummary("Obtiene un tipo de pago por ID")
            .Produces<ApiResponseDto<TipoPagoDto>>(StatusCodes.Status200OK)
            .Produces<ApiResponseDto>(StatusCodes.Status404NotFound)
            .Produces<ApiResponseDto>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto>(StatusCodes.Status500InternalServerError);

        group.MapGet("/", GetPaginated)
            .WithSummary("Obtiene tipos de pago paginados y filtrados")
            .Produces<ApiResponseDto<PagedResultDto<TipoPagoListItemDto>>>(StatusCodes.Status200OK)
            .Produces<ApiResponseDto>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto>(StatusCodes.Status500InternalServerError);

        group.MapPost("/", Create)
            .WithName("CreateTipoPago")
            .WithSummary("Crea un nuevo tipo de pago")
            .Accepts<TipoPagoDto>("application/json")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status500InternalServerError);

        group.MapPut("/{id}", Update)
            .WithName("UpdateTipoPago")
            .WithSummary("Actualiza un tipo de pago")
            .Accepts<TipoPagoDto>("application/json")
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
        var result = await queryMediator.QueryAsync(new GetTipoPagoByIdQuery { Id = id });
        return result.ToCustomMinimalApiResult();
    }

    public async Task<IResult> GetPaginated(
    IQueryMediator queryMediator,
    [FromQuery] string? q = null,
    [FromQuery] int page = 1,
    [FromQuery] int size = 10,
    [FromQuery] string sortColumn = nameof(TipoPagoListItemDto.Id),
    [FromQuery] bool sortDescending = false)
    {
        var query = new GetTipoPagosQuery
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
    [FromBody] TipoPagoDto model)
    {
        var command = new CreateTipoPagoCommand
        {
            Model = model
        };

        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }

    public async Task<IResult> Update(
    [FromServices] ICommandMediator commandMediator,
    int id,
    [FromBody] TipoPagoDto model)
    {
        var command = new UpdateTipoPagoCommand
        {
            Id = id,
            Model = model
        };

        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }
}

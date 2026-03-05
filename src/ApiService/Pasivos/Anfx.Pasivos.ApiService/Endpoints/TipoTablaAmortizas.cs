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

public class TipoTablaAmortizas : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        var group = groupBuilder.MapGroup("/")
           .WithTags("TipoTablaAmortizas");

        // GET by id
        group.MapGet("/{id}", GetById)
            .WithName("GetTipoTablaAmortizaById")
            .WithSummary("Obtiene un tipo de tabla amortiza por ID")
            .Produces<ApiResponseDto<TipoTablaAmortizaDto>>(StatusCodes.Status200OK)
            .Produces<ApiResponseDto>(StatusCodes.Status404NotFound)
            .Produces<ApiResponseDto>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto>(StatusCodes.Status500InternalServerError);

        group.MapGet("/", GetPaginated)
            .WithSummary("Obtiene tipos de tabla amortiza paginados y filtrados")
            .Produces<ApiResponseDto<PagedResultDto<TipoTablaAmortizaListItemDto>>>(StatusCodes.Status200OK)
            .Produces<ApiResponseDto>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto>(StatusCodes.Status500InternalServerError);

        group.MapPost("/", Create)
            .WithName("CreateTipoTablaAmortiza")
            .WithSummary("Crea un nuevo tipo de tabla amortiza")
            .Accepts<TipoTablaAmortizaDto>("application/json")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status500InternalServerError);

        group.MapPut("/{id}", Update)
            .WithName("UpdateTipoTablaAmortiza")
            .WithSummary("Actualiza un tipo de tabla amortiza")
            .Accepts<TipoTablaAmortizaDto>("application/json")
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
        var result = await queryMediator.QueryAsync(new GetTipoTablaAmortizaByIdQuery { Id = id });
        return result.ToCustomMinimalApiResult();
    }

    public async Task<IResult> GetPaginated(
    IQueryMediator queryMediator,
    [FromQuery] string? q = null,
    [FromQuery] int page = 1,
    [FromQuery] int size = 10,
    [FromQuery] string sortColumn = nameof(TipoTablaAmortizaListItemDto.Id),
    [FromQuery] bool sortDescending = false)
    {
        var query = new GetTipoTablaAmortizasQuery
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
    [FromBody] TipoTablaAmortizaDto model)
    {
        var command = new CreateTipoTablaAmortizaCommand
        {
            Model = model
        };

        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }

    public async Task<IResult> Update(
    [FromServices] ICommandMediator commandMediator,
    int id,
    [FromBody] TipoTablaAmortizaDto model)
    {
        var command = new UpdateTipoTablaAmortizaCommand
        {
            Id = id,
            Model = model
        };

        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }
}

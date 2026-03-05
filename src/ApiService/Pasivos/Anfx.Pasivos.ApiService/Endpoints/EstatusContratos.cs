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

public class EstatusContratos : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        var group = groupBuilder.MapGroup("/")
           .WithTags("EstatusContratos");

        // GET by id
        group.MapGet("/{id}", GetById)
            .WithName("GetEstatusContratoById")
            .WithSummary("Obtiene un estatus de contrato por ID")
            .Produces<ApiResponseDto<EstatusContratoDto>>(StatusCodes.Status200OK)
            .Produces<ApiResponseDto>(StatusCodes.Status404NotFound)
            .Produces<ApiResponseDto>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto>(StatusCodes.Status500InternalServerError);

        group.MapGet("/", GetPaginated)
            .WithSummary("Obtiene estatus de contrato paginados y filtrados")
            .Produces<ApiResponseDto<PagedResultDto<EstatusContratoListItemDto>>>(StatusCodes.Status200OK)
            .Produces<ApiResponseDto>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto>(StatusCodes.Status500InternalServerError);

        group.MapPost("/", Create)
            .WithName("CreateEstatusContrato")
            .WithSummary("Crea un nuevo estatus de contrato")
            .Accepts<EstatusContratoDto>("application/json")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status401Unauthorized)
            .Produces<ApiResponseDto<int>>(StatusCodes.Status500InternalServerError);

        group.MapPut("/{id}", Update)
            .WithName("UpdateEstatusContrato")
            .WithSummary("Actualiza un estatus de contrato")
            .Accepts<EstatusContratoDto>("application/json")
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
        var result = await queryMediator.QueryAsync(new GetEstatusContratoByIdQuery { Id = id });
        return result.ToCustomMinimalApiResult();
    }

    public async Task<IResult> GetPaginated(
    IQueryMediator queryMediator,
    [FromQuery] string? q = null,
    [FromQuery] int page = 1,
    [FromQuery] int size = 10,
    [FromQuery] string sortColumn = nameof(EstatusContratoListItemDto.Id),
    [FromQuery] bool sortDescending = false)
    {
        var query = new GetEstatusContratosQuery
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
    [FromBody] EstatusContratoDto model)
    {
        var command = new CreateEstatusContratoCommand
        {
            Model = model
        };

        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }

    public async Task<IResult> Update(
    [FromServices] ICommandMediator commandMediator,
    int id,
    [FromBody] EstatusContratoDto model)
    {
        var command = new UpdateEstatusContratoCommand
        {
            Id = id,
            Model = model
        };

        var result = await commandMediator.SendAsync(command);
        return result.ToCustomMinimalApiResult();
    }
}

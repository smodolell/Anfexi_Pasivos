using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace Anfx.Sistema.ApiService.Infrastructure;

public static class ResultExtensions
{
    /// <summary>
    /// Convierte un Result<T> de Ardalis a IResult con formato personalizado
    /// </summary>
    public static IResult ToCustomMinimalApiResult<T>(this Result<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Ok => HandleOk(result),
            ResultStatus.Created => HandleCreated(result),
            ResultStatus.NoContent => Results.NoContent(),

            // Errores
            ResultStatus.NotFound => HandleNotFound(result),
            ResultStatus.Invalid => HandleInvalid(result),
            ResultStatus.Error => HandleError(result),
            ResultStatus.Conflict => HandleConflict(result),
            ResultStatus.Unauthorized => HandleUnauthorized(result),
            ResultStatus.Forbidden => HandleForbidden(result),
            ResultStatus.Unavailable => HandleUnavailable(result),
            ResultStatus.CriticalError => HandleCriticalError(result),

            // Fallback
            _ => HandleUnknown(result)
        };
    }

    #region Handlers de Éxito

    private static IResult HandleOk<T>(Result<T> result)
    {
        return Results.Ok(new
        {
            Success = true,
            Message = result.SuccessMessage ?? "Operación exitosa",
            Data = result.Value,
            Timestamp = DateTime.UtcNow,
            TraceId = Activity.Current?.Id ?? HttpContextHelper.GetTraceId()
        });
    }

    private static IResult HandleCreated<T>(Result<T> result)
    {
        var response = new
        {
            Success = true,
            Message = "Recurso creado exitosamente",
            Data = result.Value,
            Timestamp = DateTime.UtcNow,
            TraceId = Activity.Current?.Id ?? HttpContextHelper.GetTraceId()
        };

        return Results.Created(result.Location ?? string.Empty, response);
    }

    #endregion

    #region Handlers de Error con ProblemDetails

    private static IResult HandleNotFound<T>(Result<T> result)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.5",
            Title = "Recurso no encontrado",
            Status = StatusCodes.Status404NotFound,
            Detail = GetFirstError(result, "El recurso solicitado no existe"),
            Instance = $"urn:not-found:{Guid.NewGuid()}"
        };

        AddExtensions(problemDetails, result);
        return Results.NotFound(problemDetails);
    }

    private static IResult HandleInvalid<T>(Result<T> result)
    {
        // Agrupar errores de validación por campo
        var errors = result.ValidationErrors
            .GroupBy(e => e.Identifier ?? "general")
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray()
            );

        var problemDetails = new HttpValidationProblemDetails(errors)
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            Title = "Error de validación",
            Status = StatusCodes.Status400BadRequest,
            Detail = "Los datos enviados no cumplen con las validaciones requeridas",
            Instance = $"urn:validation-error:{Guid.NewGuid()}"
        };

        AddExtensions(problemDetails, result);
        return Results.BadRequest(problemDetails);
    }

    private static IResult HandleError<T>(Result<T> result)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.6.1",
            Title = "Error interno del servidor",
            Status = StatusCodes.Status500InternalServerError,
            Detail = GetFirstError(result, "Ha ocurrido un error inesperado"),
            Instance = $"urn:server-error:{Guid.NewGuid()}"
        };

        AddExtensions(problemDetails, result, includeSensitiveData: IsDevelopment());
        return Results.Problem(problemDetails);
    }

    private static IResult HandleConflict<T>(Result<T> result)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.10",
            Title = "Conflicto de datos",
            Status = StatusCodes.Status409Conflict,
            Detail = GetFirstError(result, "El recurso ya existe o está en conflicto"),
            Instance = $"urn:conflict:{Guid.NewGuid()}"
        };

        AddExtensions(problemDetails, result);
        return Results.Conflict(problemDetails);
    }

    private static IResult HandleUnauthorized<T>(Result<T> result)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.2",
            Title = "No autorizado",
            Status = StatusCodes.Status401Unauthorized,
            Detail = "Debe autenticarse para acceder a este recurso",
            Instance = $"urn:unauthorized:{Guid.NewGuid()}"
        };

        AddExtensions(problemDetails, result);
        return Results.Json(problemDetails, statusCode: StatusCodes.Status401Unauthorized);
    }

    private static IResult HandleForbidden<T>(Result<T> result)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.4",
            Title = "Acceso denegado",
            Status = StatusCodes.Status403Forbidden,
            Detail = "No tiene permisos para acceder a este recurso",
            Instance = $"urn:forbidden:{Guid.NewGuid()}"
        };

        AddExtensions(problemDetails, result);
        return Results.Json(problemDetails, statusCode: StatusCodes.Status403Forbidden);
    }

    private static IResult HandleUnavailable<T>(Result<T> result)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.6.4",
            Title = "Servicio no disponible",
            Status = StatusCodes.Status503ServiceUnavailable,
            Detail = GetFirstError(result, "El servicio no está disponible temporalmente"),
            Instance = $"urn:unavailable:{Guid.NewGuid()}"
        };

        AddExtensions(problemDetails, result);
        return Results.Json(problemDetails, statusCode: StatusCodes.Status503ServiceUnavailable);
    }

    private static IResult HandleCriticalError<T>(Result<T> result)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.6.1",
            Title = "Error crítico del sistema",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "Ha ocurrido un error crítico. Por favor contacte al administrador.",
            Instance = $"urn:critical:{Guid.NewGuid()}"
        };

        AddExtensions(problemDetails, result, includeSensitiveData: IsDevelopment());
        return Results.Problem(problemDetails);
    }

    private static IResult HandleUnknown<T>(Result<T> result)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.6.1",
            Title = "Error desconocido",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "Ha ocurrido un error no controlado",
            Instance = $"urn:unknown:{Guid.NewGuid()}"
        };

        AddExtensions(problemDetails, result, includeSensitiveData: IsDevelopment());
        return Results.Problem(problemDetails);
    }

    #endregion

    #region Métodos auxiliares

    private static void AddExtensions(ProblemDetails problemDetails, Ardalis.Result.IResult result, bool includeSensitiveData = false)
    {
        // Siempre incluir timestamp y traceId
        problemDetails.Extensions["timestamp"] = DateTime.UtcNow.ToString("O");
        problemDetails.Extensions["traceId"] = Activity.Current?.Id ?? HttpContextHelper.GetTraceId();

        // Incluir errores si existen
        if (result.Errors?.Any() == true)
        {
            problemDetails.Extensions["errors"] = result.Errors;
        }

        // Incluir detalles sensibles solo en desarrollo
        if (includeSensitiveData && result is Result<object> resultObj)
        {
            problemDetails.Extensions["resultStatus"] = resultObj.Status.ToString();
            if (resultObj.ValidationErrors?.Any() == true)
            {
                problemDetails.Extensions["validationErrors"] = resultObj.ValidationErrors;
            }
        }
    }

    private static string GetFirstError(Ardalis.Result.IResult result, string defaultMessage)
    {
        return result.Errors?.FirstOrDefault() ?? defaultMessage;
    }

    private static bool IsDevelopment()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    }

    #endregion
}


/// <summary>
/// Helper para obtener TraceId desde HttpContext
/// </summary>
public static class HttpContextHelper
{
    private static readonly AsyncLocal<HttpContext?> _currentContext = new();

    public static void SetHttpContext(HttpContext? context) => _currentContext.Value = context;

    public static string GetTraceId()
    {
        return _currentContext.Value?.TraceIdentifier ??
               Activity.Current?.Id ??
               Guid.NewGuid().ToString();
    }
}

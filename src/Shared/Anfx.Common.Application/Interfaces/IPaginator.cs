using Anfx.Common.Application.DTOs;

namespace Anfx.Common.Application.Interfaces;

public interface IPaginator
{
    Task<PagedResultDto<TDestination>> PaginateAsync<T, TDestination>(
        IQueryable<T> query,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
        where T : class
        where TDestination : class, new();

    PagedResultDto<T> CreatePagedResult<T>(
        List<T> items,
        int pageNumber,
        int pageSize,
        long totalCount)
        where T : class, new();
}

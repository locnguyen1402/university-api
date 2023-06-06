using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Constants;

namespace UniversityApi.Utils;

public class PaginationInfo
{
    public int Page { get; private set; }
    public int PageSize { get; private set; }
    public int TotalItems { get; set; }
    // public IQueryable<TEntity> ListQuery { get; private set; }
    public PaginationInfo(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }

    public static async Task<PaginationInfo> GetPaginationInfoAsync<TEntity>(int page, int pageSize, IQueryable<TEntity> query)
    {
        var totalItems = await query.CountAsync();

        return new(page, pageSize)
        {
            TotalItems = totalItems
        };
    }

    public static async Task AttachPaginationInfoToHeader<TEntity>(int page, int pageSize, IQueryable<TEntity> query)
    {
        var paginationInfo = await GetPaginationInfoAsync(page, pageSize, query);

        var paginationString = JsonSerializer.Serialize(paginationInfo, JsonConstant.jsonSerializerOptions);

        var httpContext = new HttpContextAccessor().HttpContext;

        httpContext?.Response.Headers.Add("X-Pagination", paginationString);
    }

    public static async Task<List<TEntity>> ToPaginatedListAsync<TEntity>(int page, int pageSize, IQueryable<TEntity> query)
    {
        return await query.Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
    }
}
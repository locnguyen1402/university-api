namespace UniversityApi.Controllers.Queries;

public class PaginationQuery
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 2;

    // public PaginationQuery(int page)
    // {
    //     Page = page;
    // }

    // public PaginationQuery(int page, int pageSize) : this(page)
    // {
    //     PageSize = pageSize;
    // }
}
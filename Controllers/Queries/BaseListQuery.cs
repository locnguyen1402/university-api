namespace UniversityApi.Controllers.Queries;

public class BaseListQuery : PaginationQuery
{
    public string? keyword { get; set; }
}

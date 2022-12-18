using System.Text.Json.Serialization;

namespace Application.Common.Model;

public class PaginatedList<T>
{
    public List<T> Items { get; }

    [JsonPropertyName("page_number")]
    public int PageNumber { get; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; }

    [JsonPropertyName("total_count")]
    public int TotalCount { get; }

    public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    [JsonPropertyName("has_pervious_page")]
    public bool HasPreviousPage => PageNumber > 1;

    [JsonPropertyName("has_next_page")]
    public bool HasNextPage => PageNumber < TotalPages;
}
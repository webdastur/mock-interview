using System.Text.Json.Serialization;

namespace Application.Common.Model;

public class PaginatedRequestModel
{
    public int Page { get; set; } = 1;

    [JsonPropertyName("size")]
    public int PageSize { get; set; } = 10;
}

using System.Text.Json.Serialization;

namespace Application.Common.Model;

public class FilteredRequestModel
{
    public int Page { get; set; } = 1;

    [JsonPropertyName("size")]
    public int PageSize { get; set; } = 10;

    [JsonPropertyName("field-name")]
    public string FieldName { get; set; } = "Id";

    [JsonPropertyName("is-ask")]
    public bool IsAsc { get; set; } = true;

    public string Search { get; set; }
}

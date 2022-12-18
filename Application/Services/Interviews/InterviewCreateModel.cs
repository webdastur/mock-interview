using System.Text.Json.Serialization;

namespace Application.Services.Interviews;

public class InterviewCreateModel
{
    public string Title { get; set; }
    public string Description { get; set; }

    [JsonPropertyName("category_id")]
    public required int CategoryId { get; set; }
}

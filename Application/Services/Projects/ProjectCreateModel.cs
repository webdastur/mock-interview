using Application.Common.Model;
using System.Text.Json.Serialization;

namespace Application.Services.Projects;

public class ProjectCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }

    [JsonPropertyName("image_id")]
    public int? ImageId { get; set; }
}

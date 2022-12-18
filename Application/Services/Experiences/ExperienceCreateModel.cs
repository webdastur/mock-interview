using System.Text.Json.Serialization;

namespace Application.Services.Experiences;

public class ExperienceCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }

    [JsonPropertyName("level_id")]
    public int LevelId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}

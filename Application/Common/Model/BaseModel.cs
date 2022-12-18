using System.Text.Json.Serialization;

namespace Application.Common.Model;

public class BaseModel
{
    [JsonPropertyOrder(1)]
    public int Id { get; set; }
}

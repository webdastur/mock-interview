using System.Text.Json.Serialization;

namespace Application.Identity;

public record TokenResponse
    (
        string Token,
        [property: JsonPropertyName("expired_date")] DateTime ExpiredDate
    );

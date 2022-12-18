using Application.Services.Files;
using System.Text.Json.Serialization;

namespace Application.Services.Users;

public class CreateUserModel
{
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("middle_name")]
    public string MiddleName { get; set; }
    public string Phone { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public FileModel Image { get; set; }
}

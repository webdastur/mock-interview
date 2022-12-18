﻿using Application.Common.Model;
using System.Text.Json.Serialization;

namespace Application.Services.Users;

public class UserModel : BaseModel
{
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("middle_name")]
    public string MiddleName { get; set; }
    public string Phone { get; set; }
    public string Login { get; set; }
    public string Role { get; set; }
    public int? ImageId { get; set; }
}

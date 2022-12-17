namespace Application.Identity;

public record TokenResponse(string Token, DateTime ExpiredDate);

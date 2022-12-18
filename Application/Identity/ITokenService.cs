namespace Application.Identity;

public interface ITokenService
{
    TokenResponse GetTokenAsync(TokenRequest request);
}

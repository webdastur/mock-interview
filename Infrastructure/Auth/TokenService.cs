using Application.Identity;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Infrastructure.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Auth;

public class TokenService : ITokenService
{
    private readonly JwtSetting jwtSettings;
    private readonly ApplicationDbContext context;
    private DateTime expiresAt;

    public TokenService(IOptions<JwtSetting> jwtSettings, ApplicationDbContext context)
    {
        this.jwtSettings = jwtSettings.Value;
        this.context = context;
        this.expiresAt = DateTime.UtcNow.AddDays(jwtSettings.Value.TokenExpirationInDays);
    }

    public TokenResponse GetTokenAsync(TokenRequest request)
    {
        var user = context.Users.Where(x => x.Login == request.Login).FirstOrDefault();

        var passwordHasher = PasswordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);

        if (!passwordHasher)
        {
            throw new UnauthorizedAccessException();
        }

        return GenerateTokensAndUpdateUser(user);
    }

    private TokenResponse GenerateTokensAndUpdateUser(User user)
    {
        string token = GenerateJwt(user);

        return new TokenResponse(token, expiresAt);
    }

    private string GenerateJwt(User user) =>
        GenerateEncryptedToken(GetSigningCredentials(), GetClaims(user));

    private string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
           claims: claims,
           expires: expiresAt,
           signingCredentials: signingCredentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    private static IEnumerable<Claim> GetClaims(User user) =>
        new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role.ToString())
        };

    private SigningCredentials GetSigningCredentials()
    {
        byte[] secret = Encoding.UTF8.GetBytes(jwtSettings.Key);
        return new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);
    }
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DienMayLongBien.Domain.Entities;
using DienMayLongBien.Domain.Shared;
using Microsoft.IdentityModel.Tokens;

namespace DienMayLongBien.Utils;

public class JwtService(JwtSetting jwtSetting)
{
    public string GenerateJwtToken(User user)
    {
        string issuer = jwtSetting.Issuer;
        string audience = jwtSetting.Audience;
        string secretKey = jwtSetting.Secret;
        int expirationMinutes = jwtSetting.ExpirationInMinutes;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] { new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        byte[] randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}

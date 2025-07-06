using System.Text;
using DienMayLongBien.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DienMayLongBien.Configurations;

public static class JwtConfiguration
{
    public static IServiceCollection AddJwt(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var issuer =
            configuration["ISSUER"] ?? throw new InvalidOperationException("Issuer is missing");
        var audience =
            configuration["AUDIENCE"] ?? throw new InvalidOperationException("Audience is missing");
        var secretKey =
            configuration["JWT_SECRET"]
            ?? throw new InvalidOperationException("Secret Key is missing");
        var ExpirationInMinutes =
            configuration["JWT_EXPIRATION_IN_MINUTES"]
            ?? throw new InvalidOperationException("Expiration in minutes is missing");

        JwtSetting jwtSetting =
            new()
            {
                Issuer = issuer,
                Audience = audience,
                Secret = secretKey,
                ExpirationInMinutes = int.Parse(ExpirationInMinutes)
            };

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };

        services.AddSingleton(tokenValidationParameters);

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });

        services.AddAuthorization();

        services.AddSingleton(jwtSetting);

        return services;
    }
}

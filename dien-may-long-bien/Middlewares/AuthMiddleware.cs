using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using DienMayLongBien.Database.Inrceptors;
using DienMayLongBien.Domain.Entities;
using DienMayLongBien.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace DienMayLongBien.Middlewares;

public class AuthMiddleware(IConfiguration configuration) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // configure issuer
        string issuer =
            configuration["ISSUER"] ?? throw new ArgumentNullException("Issuer is not configured");

        string? authHeader = context.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authHeader) || !authHeader.Contains("Bearer "))
        {
            await next.Invoke(context);
            return;
        }

        // get token
        authHeader = authHeader.Replace("Bearer ", "");
        JwtSecurityTokenHandler? handler = new();
        JwtSecurityToken? jwtSecurityToken = handler.ReadJwtToken(authHeader);
        IEnumerable<Claim>? claims = jwtSecurityToken.Claims;

        if (!claims.Any(c => c.Issuer.Equals(issuer, StringComparison.InvariantCultureIgnoreCase)))
        {
            await next.Invoke(context);
            return;
        }

        // check user
        string? id =
            claims
                .FirstOrDefault(c =>
                    c.Type.Equals("sub", StringComparison.InvariantCultureIgnoreCase)
                )
                ?.Value ?? string.Empty;

        if (!Guid.TryParse(id, out Guid userId))
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            var response = new ResponseResult<string>
            {
                IsSuccess = false,
                Value = null!,
                Message = "Invalid user ID"
            };

            await context.Response.WriteAsJsonAsync(response, default);

            return;
        }

        AppDbContext dbContext = context.RequestServices.GetRequiredService<AppDbContext>();
        User? user = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            var response = new ResponseResult<string>
            {
                IsSuccess = false,
                Value = null!,
                Message = "User not found"
            };

            await context.Response.WriteAsJsonAsync(response, default);

            return;
        }

        // Set current user
        CurrentUser currentUser = context.RequestServices.GetRequiredService<CurrentUser>();
        currentUser.SetUser(user);

        // Set user claims for the current request
        var claimsList = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, user.FullName)
        };

        var identity = new ClaimsIdentity(claimsList, "Bearer");
        context.User = new ClaimsPrincipal(identity);

        await next.Invoke(context);
    }
}

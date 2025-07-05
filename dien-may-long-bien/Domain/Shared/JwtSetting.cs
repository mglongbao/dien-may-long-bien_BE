namespace DienMayLongBien.Domain.Shared;

public class JwtSetting
{
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required string Secret { get; set; }
    public int ExpirationInMinutes { get; set; } = 60 * 24; // Default to 1 day
}

using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public Guid UserId { get; set; }

    public required string Token { get; set; }
    public required string JwtId { get; set; }
    public required DateTime ExpiryDate { get; set; }
    public required bool Invalidated { get; set; }

    // Navigation property
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
}

using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class User : BaseEntity
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }

    // Navigation properties
    public ICollection<UserAction> UserActions { get; set; } = [];
    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<ProductEditHistory> ProductEditHistories { get; set; } = [];
}
